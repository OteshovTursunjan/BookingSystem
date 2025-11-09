using BookingSystem.Application.DTOs.User;
using BookingSystem.Application.Feature.User.Queries;
using BookingSystem.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Feature.User.Handler;

public  class GetUserByIdHandler : IRequestHandler<GetUserByIdQueries , LoginUserModel>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetUserByIdHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<LoginUserModel> Handle(GetUserByIdQueries request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.id.ToString());
        var use = new LoginUserModel() { Email = user.Email, Password = user.Email };
        return use;
        


    }
}
