using BookingSystem.Application.DTOs.User;
using BookingSystem.Application.Feature.User.Command;
using BookingSystem.Application.Feature.User.Queries;
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
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById( Guid id)
    {
        if(!ModelState.IsValid)
            return NotFound();
        var result = await _mediator.Send(new GetUserByIdQueries(id));
        return Ok(result);
    }
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(LoginUserModel id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _mediator.Send(new DeleteUserCommand(id));
        return Ok(result);
    }
    public IActionResult Index()
    {
        return View();
    }
}
