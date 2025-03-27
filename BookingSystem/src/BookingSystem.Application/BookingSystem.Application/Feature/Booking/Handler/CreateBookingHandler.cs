using BookingSystem.Application.Feature.Booking.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Handler;

public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, bool>
{
    private readonly IBookingRepository _bookingRepository;
    public CreateBookingHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
      if(request.CreateBookingModel.BookingDate.DayOfWeek == DayOfWeek.Saturday
        || request.CreateBookingModel.BookingDate.DayOfWeek == DayOfWeek.Sunday)
        {
            throw new ArgumentException("Day of week we do not work");
        }

        TimeOnly startTime = new TimeOnly(9, 0);  // 09:00
        TimeOnly endTime = new TimeOnly(18, 0);
        
        if(request.CreateBookingModel.BookingTime >= startTime && request.CreateBookingModel.BookingTime <= endTime)
        {
            throw new ArgumentException("This time is not avaible");
        }


        var newbook = new BookingSystem.Domain.Entity.Booking()
        {
            ServiceId = request.CreateBookingModel.ServiceId,
            UserId = request.CreateBookingModel.UserId,
            BookingDate = request.CreateBookingModel.BookingDate,
            BookingTime = request.CreateBookingModel.BookingTime,
            BookingStatus = BookingSystem.Domain.Enum.BookingStatus.Progres
        };
        await _bookingRepository.AddAsync(newbook);
        return true;
    }
}
