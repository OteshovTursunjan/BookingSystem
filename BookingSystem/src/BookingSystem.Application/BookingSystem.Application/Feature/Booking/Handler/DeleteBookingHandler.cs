
using BookingSystem.Application.Feature.Booking.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Handler;

public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, bool>
{
    private readonly IBookingRepository bookingRepository;
    public DeleteBookingHandler(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetFirstAsync(u => u.id == request.id);
        if (booking == null)
        {
            return false;
        }
        await bookingRepository.DeleteAsync(booking);
        return true;
    }
}
