// Purpose: This file contains the NewUserDto class, which is used to transfer data from the NewUserDto to the User model.

namespace Bangazon.Dtos;

public record NewUserDto
{
    public string Username { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Uid { get; set; }
}
