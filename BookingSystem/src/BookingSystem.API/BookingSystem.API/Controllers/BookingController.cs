using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.DTOs.Update;
using BookingSystem.Application.Feature.Booking.Command;
using BookingSystem.Application.Feature.Booking.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;

public class BookingController : Controller
{
    private readonly IMediator mediator;
    public BookingController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("GetBooking")]
    public async Task<IActionResult> GetBooking(Guid id)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new GetBookingByIdQueries(id));
        return Ok(result);
    }
    [HttpPost("CreateBooking")]
    public async Task<IActionResult> CreateBooking([FromQuery] CreateBookingModel createBookingModel)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new CreateBookingCommand(createBookingModel));
        return Ok(res);
    }
    [HttpPut("UpdateBooking")]
    public async Task<IActionResult> UpdateBooking(UpdateBookingModel updateBookingModel)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new  UpdateBookingCommand(updateBookingModel));
        return Ok(result);
    }
    [HttpDelete("DeleteBooking")]
    public async Task<IActionResult> DeleteBooking(Guid id)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new DeleteBookingCommand(id)); 
        return Ok(result);
    }
    public IActionResult Index()
    {
        return View();
    }
}
