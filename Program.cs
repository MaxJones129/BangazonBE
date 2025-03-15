using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Bangazon.Models;
using Bangazon.Dtos;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//  This configures how the backend handles requests from the frontend
// It's essentially giving permission to other applications to access your backend.
// It will only handle requests from the address in the WithOrgins function
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

// start
app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.User.ToList();
});

app.MapGet("/paymentTypes", (BangazonDbContext db) =>
{
    return db.PaymentType.ToList();
});

app.MapGet("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    var user = db.User
        .Include(u => u.Products)
        .FirstOrDefault(u => u.Id == id);

    return user is not null ? Results.Ok(user) : Results.NotFound();
});

app.MapGet("/carts/user/{userId}", (BangazonDbContext db, int userId) =>
{
    var cart = db.Cart
        .Include(c => c.CartItems)
        .FirstOrDefault(c => c.UserId == userId && c.CompletionDate == null); // Fetch active cart

    return cart is not null ? Results.Ok(cart) : Results.NotFound();
});

app.MapGet("/carts/{cartId}", async (BangazonDbContext db, int cartId) =>
{
    var cart = await db.Cart
        .Include(c => c.CartItems)
        .FirstOrDefaultAsync(c => c.Id == cartId); // Fetch by Cart ID

    return cart is not null ? Results.Ok(cart) : Results.NotFound();
});

app.MapGet("/carts/completed", (BangazonDbContext db) =>
{
    var completedCarts = db.Cart
        .Where(c => c.CompletionDate != null) // Filter only completed carts
        .Include(c => c.CartItems)
        .ThenInclude(cI => cI.Product)
        .ToList(); // Execute synchronously

    return completedCarts.Any() ? Results.Ok(completedCarts) : Results.NotFound();
});

app.MapGet("/api/cartItems/{cartId}", (BangazonDbContext db, int cartId) =>
{
    var cartItems = db.CartItem
        .Where(ci => ci.CartId == cartId)
        .Include(ci => ci.Product)
        .ToList();

    return Results.Ok(cartItems);
});

app.MapGet("/api/users/uid/{uid}", (BangazonDbContext db, string uid) =>
{
    var user = db.User
        .Include(u => u.Products)
        .FirstOrDefault(u => u.Uid == uid);

    return user is not null ? Results.Ok(user) : Results.NotFound();
});

app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Product
        .Include(r => r.User)
        .ToList();
});

app.MapPost("/checkuser", (BangazonDbContext db, User userCheck) =>
{
    User? user = db.User.FirstOrDefault(u => u.Uid == userCheck.Uid);

    if (user == null)
        {
            return Results.NotFound("User is not registered");
        }

        return Results.Ok(user);
    });

app.MapPost("/register", (BangazonDbContext db, NewUserDto userRegister) =>
{
    User newUser = new User
    {
        Username = userRegister.Username,
        Address = userRegister.Address,
        Email = userRegister.Email,
        Uid = userRegister.Uid
    };

    db.User.Add(newUser);
    db.SaveChanges();

    return Results.Created($"/users/{newUser.Id}", newUser);
});

app.MapPost("/api/carts", (BangazonDbContext db, CartDto cartRequest) =>
{
    if (db.User == null)  // Fix table reference
    {
        return Results.Problem("Database User table is null.");
    }

    // Check if user exists
    var userExists = db.User.Any(u => u.Id == cartRequest.UserId);
    if (!userExists)
    {
        return Results.BadRequest("User does not exist.");
    }

    // Create new cart
    Cart newCart = new Cart
    {
        UserId = cartRequest.UserId,
        TotalCost = cartRequest.TotalCost ?? 0m,  // Default to 0 if not provided
        CompletionDate = cartRequest.CompletionDate,
        Address = cartRequest.Address ?? "No Address Provided"
    };

    db.Cart.Add(newCart);
    db.SaveChanges();

    return Results.Created($"/api/carts/{newCart.Id}", newCart);
});

app.MapPost("/cart/{cartId}/add/{productId}", (BangazonDbContext db, int cartId, int productId, AddToCartRequest request) =>
{
    // Check if the cart exists and is active
    var cart = db.Cart.FirstOrDefault(c => c.Id == cartId && c.CompletionDate == null);
    if (cart == null)
    {
        return Results.NotFound(new { message = "No active cart found with this cart ID." });
    }

    // Check if the product exists
    if (!db.Product.Any(p => p.Id == productId))
    {
        return Results.NotFound(new { message = "Product not found." });
    }

    // Create the cart item
    var newCartItem = new CartItem
    {
        CartId = cart.Id,
        ProductId = productId,
        Quantity = request.Quantity ?? 1 // Default quantity to 1 if not provided
    };

    db.CartItem.Add(newCartItem);
    db.SaveChanges();

    return Results.Created($"/cart-items/{newCartItem.Id}", newCartItem);
});

app.MapDelete("/cart/{userId}/remove-product/{productId}", (BangazonDbContext db, int userId, int productId) =>
{
    Console.WriteLine($"Received DELETE request for userId: {userId}, productId: {productId}");

    var cart = db.Cart.FirstOrDefault(o => o.UserId == userId && o.CompletionDate == null);
    if (cart == null)
    {
        Console.WriteLine("No active cart found for this user.");
        return Results.NotFound("No active cart found.");
    }

    var cartItem = db.CartItem.FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == productId);
    if (cartItem == null)
    {
        Console.WriteLine("Product not found in cart.");
        return Results.NotFound("Product not found.");
    }

    db.CartItem.Remove(cartItem);
    db.SaveChanges();
    Console.WriteLine("Product removed successfully.");
    return Results.Ok("Product removed.");
});

app.MapGet("/api/users/{id}/products", (BangazonDbContext db, int id) =>
{
    var products = db.Product
        .Where(p => p.UserId == id) // Filter products by User ID
        .ToList(); // Synchronous call

    return products.Any() ? Results.Ok(products) : Results.NotFound();
});

app.MapPost("/cart/{userId}/checkout", (BangazonDbContext db, int userId, CheckoutRequest checkoutRequest) =>
{
    var cart = db.Cart.FirstOrDefault(c => c.UserId == userId && c.CompletionDate == null);
    if (cart == null)
    {
        return Results.NotFound("No active cart found.");
    }

    cart.Address = checkoutRequest.Address;
    cart.PaymentId = checkoutRequest.PaymentId;
    cart.CompletionDate = DateTime.UtcNow;

    db.SaveChanges();
    return Results.Ok("Checkout successful!");
});

app.Run();
