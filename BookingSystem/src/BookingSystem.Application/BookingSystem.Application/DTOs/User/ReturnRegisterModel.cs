

namespace BookingSystem.Application.DTOs.User;

public  class ReturnRegisterModel
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public DateTime DateTime { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}
