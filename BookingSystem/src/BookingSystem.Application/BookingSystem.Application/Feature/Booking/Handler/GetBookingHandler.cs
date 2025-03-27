using BookingSystem.Application.DTOs.Get;
using BookingSystem.Application.Feature.Booking.Queries;
using BookingSystem.Infrastucture.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Feature.Booking.Handler;

public class GetBookingHandler : IRequestHandler<GetBookingByIdQueries, GetBookingModel>
{
    private readonly IBookingRepository bookingRepository;
    public GetBookingHandler(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<GetBookingModel> Handle(GetBookingByIdQueries request, CancellationToken cancellationToken)
    {
        var bookin = await bookingRepository.GetFirstAsync(u => u.id == request.id);    
        if(bookin == null)
        {
            return null;
        }
        var model = new GetBookingModel()
        {
            UserId = bookin.UserId,
            ServiceId = bookin.ServiceId,
            BookingDate = bookin.BookingDate,
            BookingTime = bookin.BookingTime,
            Status = bookin.BookingStatus,
        };
        return model;
    }
}
