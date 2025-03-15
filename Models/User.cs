using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Uid { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Cart> Carts { get; set; } = new();
    public List<Product> Products { get; set; }

}
