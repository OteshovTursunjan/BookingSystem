

using MediatR;

namespace BookingSystem.Application.Feature.Service.Command;

public  record DeleteServiceCommand(Guid id) : IRequest<bool>;

