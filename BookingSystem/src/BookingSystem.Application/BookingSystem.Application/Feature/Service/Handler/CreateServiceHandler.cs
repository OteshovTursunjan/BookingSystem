
using BookingSystem.Application.Feature.Service.Command;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Service.Handler;

public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, bool>
{
    private readonly IServiceRepository _serviceRepository;
    public CreateServiceHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public async Task<bool> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new BookingSystem.Domain.Entity.Service()
        {
            ProviderUserId = request.createServiceModel.ProviderUserId,
            Name = request.createServiceModel.Name, 
            Description = request.createServiceModel.Description,
            Categories = request.createServiceModel.Categories,
            Price = request.createServiceModel.Price,

        };
       await _serviceRepository.AddAsync(service);
        return true;  
    }

 
  
}
