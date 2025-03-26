

using BookingSystem.Application.Feature.Review.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Handler;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, bool>
{
    private readonly IReviewRepository reviewRepository;
    public UpdateReviewHandler(IReviewRepository reviewRepository)
    {
        this.reviewRepository = reviewRepository;
    }

    public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await reviewRepository.GetFirstAsync(u => u.UserID == request.UpdateReviewModel.UserID);
        var review2 = await reviewRepository.GetFirstAsync(u => u.ServiceID == request.UpdateReviewModel.ServiceID);
        if(review2 != review)
        {
            return false;
        }
        review.Comment = request.UpdateReviewModel.Comment;
        await reviewRepository.UpdateAsync(review);
        return true;

    }
}
