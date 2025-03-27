using BookingSystem.Application.DTOs.Get;
using BookingSystem.Application.Feature.Service.Queries;
using BookingSystem.Infrastucture.Repository;
using MediatR;


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
            Categories = service.Categories,
            Rating = Math.Round(service.Rating, 1)

        };
        return res;
    }
}
