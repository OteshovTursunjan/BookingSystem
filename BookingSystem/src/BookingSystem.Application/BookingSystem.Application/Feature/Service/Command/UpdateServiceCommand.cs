using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.DTOs.Update;
using MediatR;

namespace BookingSystem.Application.Feature.Service.Command;

public record UpdateServiceCommand(UpdateServiceModel UpdateServiceModel): IRequest<bool>;
