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
        var newbook = new BookingSystem.Domain.Entity.Booking()
        {
            ServiceId = request.CreateBookingModel.ServiceId,
            UserId = request.CreateBookingModel.UserId,
            DateTime = request.CreateBookingModel.DateTime,
            BookingStatus = BookingSystem.Domain.Enum.BookingStatus.Progres
        };
        await _bookingRepository.AddAsync(newbook);
        return true;
    }
}
