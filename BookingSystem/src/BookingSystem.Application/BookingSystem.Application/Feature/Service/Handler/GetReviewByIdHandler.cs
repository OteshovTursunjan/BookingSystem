using BookingSystem.Application.DTOs.Get;
using BookingSystem.Application.Feature.Service.Queries;
using BookingSystem.Infrastucture.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Feature.Service.Handler;

public class GetReviewByIdHandler : IRequestHandler<GetServiceByIdQueries, GetServiceModel>
{
    private readonly IServiceRepository serviceRepository;
    public GetReviewByIdHandler(IServiceRepository serviceRepository)
    {
        this.serviceRepository = serviceRepository;
    }

    public async Task<GetServiceModel> Handle(GetServiceByIdQueries request, CancellationToken cancellationToken)
    {
        var service = await serviceRepository.GetFirstAsync(u => u.id == request.id);
        if (service == null)
        {
            return null;
        }
        var res = new GetServiceModel()
        {
            Description = service.Description,
            Price = service.Price,
            Name = service.Name,
            Categories  = service.Categories,

        };
        return res;
    }
}
