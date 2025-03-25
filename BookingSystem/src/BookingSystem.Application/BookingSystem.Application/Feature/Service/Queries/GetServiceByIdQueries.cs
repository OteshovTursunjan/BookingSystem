

using BookingSystem.Application.DTOs.Get;
using MediatR;

namespace BookingSystem.Application.Feature.Service.Queries;
public record GetServiceByIdQueries(Guid id) : IRequest<GetServiceModel>;

