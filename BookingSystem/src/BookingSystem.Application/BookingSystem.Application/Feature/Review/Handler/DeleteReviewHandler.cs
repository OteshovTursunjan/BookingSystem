

using BookingSystem.Application.Feature.Review.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Handler;

public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, bool>
{
    private readonly IReviewRepository _reviewRepository;
    public DeleteReviewHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetFirstAsync(u => u.id == request.id);
        if (review == null)
        {
            return false;
        }
        await _reviewRepository.UpdateAsync(review);
        return true;
    }
}
