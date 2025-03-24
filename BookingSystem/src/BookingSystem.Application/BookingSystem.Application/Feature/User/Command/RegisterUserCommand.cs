using MediatR;
using BookingSystem.Application.DTOs.User;
using System.Net;

namespace BookingSystem.Application.Feature.User.Command;

public  record RegisterUserCommand(RegisterUserModel registerUserModel) : IRequest<bool>;