

using BookingSystem.Application.DTOs.Update;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Command;

public record UpdateBookingCommand(UpdateBookingModel UpdateBookingModel) : IRequest<bool>;

