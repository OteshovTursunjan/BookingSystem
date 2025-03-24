
using BookingSystem.Application.DTOs.User;
using MediatR;
namespace BookingSystem.Application.Feature.User.Command;

public  record LoginUserCommand(LoginUserModel loginUserModel) : IRequest<ReturnRegisterModel>;

