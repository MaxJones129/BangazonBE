using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtSale { get; set; } = 0.00m;
    public bool Shipped { get; set; } = false;
    public Cart? Cart { get; set; }
    public Product? Product { get; set; }

}
