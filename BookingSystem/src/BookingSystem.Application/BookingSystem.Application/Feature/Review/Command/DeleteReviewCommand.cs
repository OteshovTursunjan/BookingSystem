

using MediatR;

namespace BookingSystem.Application.Feature.Review.Command;

public  record DeleteReviewCommand(Guid id) : IRequest<bool>;