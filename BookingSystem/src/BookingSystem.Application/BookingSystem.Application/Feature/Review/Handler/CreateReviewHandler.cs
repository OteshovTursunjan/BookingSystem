
using BookingSystem.Application.Feature.Review.Command;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Handler;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, bool>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IServiceRepository _serviceRepository;
    public CreateReviewHandler(IReviewRepository reviewRepository, IServiceRepository serviceRepository)
    {
        _reviewRepository = reviewRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {

        int rate = Convert.ToInt32(request.CreateReviewModel.Ratings);
        bool ratecalculate = await CalculateRate(rate, request.CreateReviewModel.ServiceID);

        if(ratecalculate is false)
        {
            return false;
        }

        var newreview = new BookingSystem.Domain.Entity.Review()
        {
            ServiceID = request.CreateReviewModel.ServiceID,
            UserID = request.CreateReviewModel.UserID,
            Ratings = rate,
            Comment = request.CreateReviewModel.Comment,
        };
        await _reviewRepository.AddAsync(newreview);
        return true;
    }
    public async Task<bool> CalculateRate(int rate, Guid ServiceID)
    {
        var service = await _serviceRepository.GetFirstAsync(u => u.id == ServiceID);
        if (service == null)
        {
            return false;
        }
        service.NumberOfUserWhoRate += 1;
        await _serviceRepository.UpdateAsync(service);
        
        service.Rating = (service.Rating + rate ) / service.NumberOfUserWhoRate;
        var  res = await _serviceRepository.UpdateAsync(service);
        
        if(res == null)
        {
            return false;
        }
        return true;
    }
}
