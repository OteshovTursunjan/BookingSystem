
using BookingSystem.Application.DTOs.User;
using MediatR;

namespace BookingSystem.Application.Feature.User.Command;

public record DeleteUserCommand(LoginUserModel LoginUserModel) : IRequest<bool>;

