using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

public class BangazonDbContext : DbContext
{
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<PaymentType> PaymentType { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<User> Users { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Send data to Categories
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and gadgets" },
            new Category { CategoryId = 2, Name = "Books", Description = "Various books and literature" }
        });

        // Send data to Orders
        modelBuilder.Entity<Cart>().HasData(new Cart[]
        {
            new Cart { Id = 1, UserId = 2, TotalCost = 0, PaymentId = 1, CompletionDate = null, Address = "123 Main St" },
            new Cart { Id = 2, UserId = 1, TotalCost = 45.99m, PaymentId = 1, CompletionDate = null, Address = "987 South St" },
        });

        modelBuilder.Entity<CartItem>().HasData(new CartItem[]
        {
            new CartItem { Id = 1, CartId = 1, ProductId = 1, PriceAtSale = 1200, Shipped = false, Quantity = 1 },
            new CartItem { Id = 2, CartId = 1, ProductId = 2, PriceAtSale = 45, Shipped = false, Quantity = 1 },
            new CartItem { Id = 3, CartId = 2, ProductId = 3, PriceAtSale = 30, Shipped = false, Quantity = 1 },
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
            new PaymentType { Id = 1, PaymentName = "Visa" },
            new PaymentType { Id = 2, PaymentName = "MasterCard" },
            new PaymentType { Id = 3, PaymentName = "Discover" }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product { Id = 1, UserId = 1, CategoryId = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200, StockQuantity = 10, CreatedAt = DateTime.UtcNow },
            new Product { Id = 2, UserId = 2, CategoryId = 1, Name = "IPhone 14", Description = "Latest model IPhone", Price = 900, StockQuantity = 3, CreatedAt = DateTime.UtcNow },  
            new Product { Id = 3, UserId = 2, CategoryId = 1, Name = "Wired Headphones", Description = "Noise-canceling with long battery life", Price = 250, StockQuantity = 8, CreatedAt = DateTime.UtcNow }
        });
        

        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, Username = "johndoe", CreatedAt = DateTime.UtcNow, Address = "987 South St", Uid = "RplI9hf723kvcZZs", Email = "emailexample456@email.com" },
            new User { Id = 2, Username = "janedoe", CreatedAt = DateTime.UtcNow, Address = "123 Main St", Uid = "76FJhdpekly73k7K", Email = "emailexample123@email.com" }
        });
       
    }
}
