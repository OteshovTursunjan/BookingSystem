
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Domain.Entity;

public  class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
