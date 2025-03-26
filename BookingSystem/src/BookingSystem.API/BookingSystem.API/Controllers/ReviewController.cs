using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.DTOs.Update;
using BookingSystem.Application.Feature.Review.Command;
using BookingSystem.Application.Feature.Review.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;

public class ReviewController : Controller
{
    private readonly IMediator mediator;
    public ReviewController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("CreateReview")]
    public async Task<IActionResult> CreateReview(CreateReviewModel createReviewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new CreateReviewCommand(createReviewModel));  
        return Ok(res);
    }
    [HttpGet("GetReview")]
    public async Task<IActionResult> GetReview(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result  = await mediator.Send(new GetReviewByIdQueries(id));
        return Ok(result);
    }
    [HttpPut("UpdateReview")]
    public async Task<IActionResult> UpdateReview(UpdateReviewModel updateReviewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new  UpdateReviewCommand(updateReviewModel));
        return Ok(result);
    }
    [HttpDelete("DeleteReview")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new  DeleteReviewCommand(id));
        return Ok(result);
    }
        public IActionResult Index()
    {
        return View();
    }
}
