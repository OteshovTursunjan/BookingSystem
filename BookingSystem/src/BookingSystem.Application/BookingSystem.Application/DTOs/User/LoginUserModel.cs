
namespace BookingSystem.Application.DTOs.User;

public  class LoginUserModel
{

    public required string Email { get; set; }
    public required string Password { get; set; }
}
public class GetIdModel
{
    public required Guid id { get; set; }
}