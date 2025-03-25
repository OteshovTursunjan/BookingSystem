using BookingSystem.Application.DTOs.Create;
using MediatR;

namespace BookingSystem.Application.Feature.Service.Command;

public  record CreateServiceCommand(CreateServiceModel createServiceModel) : IRequest<bool>;
