
using BookingSystem.Application.Feature.Service.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Service.Handler;

public  class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, bool>
{
    private readonly IServiceRepository serviceRepository;
    public DeleteServiceHandler(IServiceRepository serviceRepository)
    {
        this.serviceRepository = serviceRepository;
    }

    public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
      var service = await serviceRepository.GetFirstAsync(u => u.id == request.id);
        if (service == null)
        {
            return false;
        }
        await serviceRepository.DeleteAsync(service);
        return true;
    }
}
