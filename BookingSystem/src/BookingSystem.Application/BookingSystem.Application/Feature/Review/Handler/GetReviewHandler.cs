

using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.Feature.Review.Queries;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Handler;

public class GetReviewHandler : IRequestHandler<GetReviewByIdQueries, CreateReviewModel>
{
    private readonly IReviewRepository reviewRepository;
    public GetReviewHandler(IReviewRepository reviewRepository)
    {
        this.reviewRepository = reviewRepository;
    }

    public async Task<CreateReviewModel> Handle(GetReviewByIdQueries request, CancellationToken cancellationToken)
    {
       var review = await reviewRepository.GetFirstAsync(u => u.id == request.id);
        if(review  == null)
        {
            throw new ArgumentException("Not found");

        }
        var returnm = new CreateReviewModel()
        {
            UserID = review.UserID,
            Comment = review.Comment,
          //  Ratings = review.Ratings,
            ServiceID = review.ServiceID,
        };
        return returnm;
    }
}
