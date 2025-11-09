using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.DTOs.Update;
using BookingSystem.Application.Feature.Service.Command;
using BookingSystem.Application.Feature.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMediator mediator;    
        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetServiceS")]
        public async Task<IActionResult> GetService(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new GetServiceByIdQueries(id));
            return Ok(result);
        }
        [HttpPut("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceModel createServiceModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new CreateServiceCommand(createServiceModel)); 
            return Ok(result);
        }
        [HttpPost("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceModel updateServiceModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new  UpdateServiceCommand(updateServiceModel));
            return Ok(result);
        }
        [HttpDelete("DeleteService")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new  DeleteServiceCommand(id));
            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
