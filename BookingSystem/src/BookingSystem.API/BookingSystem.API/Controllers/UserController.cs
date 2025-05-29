using BookingSystem.Application.DTOs.User;
using BookingSystem.Application.Feature.User.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;

public class UserController : Controller
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel registerUserModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _mediator.Send(new RegisterUserCommand(registerUserModel));
        return Ok(result);
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserModel loginUserModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result  = await _mediator.Send(new LoginUserCommand(loginUserModel));
        return Ok(result);
    }
    public IActionResult Index()
    {
        return View();
    }
}
