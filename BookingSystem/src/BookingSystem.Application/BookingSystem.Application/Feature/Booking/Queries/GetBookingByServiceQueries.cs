
using BookingSystem.Application.DTOs.Get;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Queries;

public record GetBookingByServiceQueries(Guid id) : IRequest<List<GetBookingModel>>;