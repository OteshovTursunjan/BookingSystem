

using BookingSystem.Application.DTOs.Get;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Queries;

public  record GetBookingByIdQueries(Guid id): IRequest<GetBookingModel>;

