using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public int StockQuantity { get; set; }
    [Required]
    public User User { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; }

}
