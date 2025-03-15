
namespace Bangazon.Dtos;
public class CartDto
{
    public int UserId { get; set; }
    public decimal? TotalCost { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string Address { get; set; }
}
