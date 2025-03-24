
using BookingSystem.Application.Feature.User.Command;
using BookingSystem.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Application.Feature.User.Handler;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public DeleteUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
       var user = await _userManager.FindByEmailAsync(request.LoginUserModel.Email);
        if (user == null)
        {
            throw new ArgumentException("This user does not exist");
        }
        await _userManager.DeleteAsync(user);
        return true;
    }
}
