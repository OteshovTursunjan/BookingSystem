

using BookingSystem.Application.DTOs.Update;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Command;

public  record UpdateReviewCommand(UpdateReviewModel UpdateReviewModel) : IRequest<bool>;
