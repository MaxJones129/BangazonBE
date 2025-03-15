namespace Bangazon.Dtos;

public class CheckoutRequest
{
    public string Address { get; set; }
    public int PaymentId { get; set; } // Reference to a saved payment method
}
