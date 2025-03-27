
using BookingSystem.Application.DTOs.Create;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Command;

public record CreateBookingCommand(CreateBookingModel CreateBookingModel) : IRequest<bool>;

