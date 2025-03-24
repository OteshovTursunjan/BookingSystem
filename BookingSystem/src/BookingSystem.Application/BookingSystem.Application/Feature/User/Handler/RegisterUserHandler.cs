using BookingSystem.Application.Feature.User.Command;
using BookingSystem.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Application.Feature.User.Handler;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public RegisterUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.registerUserModel.Email);
        if(user != null)
        {
            return false;
        }
        var newUser = new ApplicationUser()
        {
            UserName = request.registerUserModel.Email,
            Email = request.registerUserModel.Email,
            FirstName = request.registerUserModel.FirstName,
            LastName = request.registerUserModel.LastName,
        };
        var result = await _userManager.CreateAsync(newUser,request.registerUserModel.Password);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
}
