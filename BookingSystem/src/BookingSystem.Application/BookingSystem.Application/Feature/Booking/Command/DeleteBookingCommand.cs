
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Command;

public record DeleteBookingCommand(Guid id) : IRequest<bool>;
