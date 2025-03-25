using BookingSystem.Application.Feature.Service.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Feature.Service.Handler;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand , bool>
{
    private readonly IServiceRepository _service;
    public UpdateServiceHandler(IServiceRepository service)
    {
        _service = service;
    }

    public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _service.GetFirstAsync(u => u.ProviderUserId == request.UpdateServiceModel.ProviderUserId);
        if (service == null)
        {
            return false;
        }
        service.Price = request.UpdateServiceModel.Price;
        service.Name = request.UpdateServiceModel.Name;
        service.Description = request.UpdateServiceModel.Description;

        await _service.UpdateAsync(service);
        return true;
    }
}
