using BookingSystem.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Feature.User.Queries;

public  record GetUserByIdQueries(Guid id) : IRequest<LoginUserModel>;