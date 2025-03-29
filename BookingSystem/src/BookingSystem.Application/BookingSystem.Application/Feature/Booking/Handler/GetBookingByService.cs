using BookingSystem.Application.DTOs.Get;
using BookingSystem.Application.Feature.Booking.Queries;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Handler;

public class GetBookingByService : IRequestHandler<GetBookingByServiceQueries, List<GetBookingModel>>
{
    private readonly IBookingRepository bookingRepository;
    public GetBookingByService(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<List<GetBookingModel>> Handle(GetBookingByServiceQueries request, CancellationToken cancellationToken)
    {
        var bookin = await bookingRepository.GetAllAsync(u => u.ServiceId == request.id);
        if(bookin == null)
        {
            return null;
        }
        var re =  bookin.Select(b => new GetBookingModel
        {
            UserId = b.ServiceId,
            ServiceId = b.ServiceId,
            BookingDate = b.BookingDate.Date,
            BookingTime = b.BookingTime,
            Status = b.BookingStatus
        }).ToList();
        return re;
    }
}
