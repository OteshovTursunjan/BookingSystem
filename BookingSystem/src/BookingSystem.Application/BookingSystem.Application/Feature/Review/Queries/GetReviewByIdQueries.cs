

using BookingSystem.Application.DTOs.Create;
using MediatR;

namespace BookingSystem.Application.Feature.Review.Queries;

public record GetReviewByIdQueries(Guid id) : IRequest<CreateReviewModel> { }

