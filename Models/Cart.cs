using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Cart
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public string? Address { get; set; }
        public User User { get; set; }
        public DateTime? CompletionDate { get; set; } = null;
        public decimal TotalCost { get; set; }
        public List<Product> Products { get; set; }
        public List<CartItem> CartItems { get; set; }

}
