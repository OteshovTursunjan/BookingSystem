
using BookingSystem.Application.DTOs.Create;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Command;

public record CreateReviewCommand(CreateReviewModel CreateReviewModel) : IRequest<bool>;