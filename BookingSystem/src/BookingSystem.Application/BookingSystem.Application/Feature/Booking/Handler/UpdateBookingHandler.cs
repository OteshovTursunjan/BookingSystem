

using BookingSystem.Application.Feature.Booking.Command;
using BookingSystem.Infrastucture.Repository;
using MediatR;

namespace BookingSystem.Application.Feature.Booking.Handler;

public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, bool>
{
    private readonly IBookingRepository bookingRepository;
    public UpdateBookingHandler(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<bool> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetFirstAsync(u => u.id == request.UpdateBookingModel.id);
        if (booking == null)
        {
            return false;

        }
        booking.DateTime = request.UpdateBookingModel.NewDate;
        await bookingRepository.UpdateAsync(booking);
        return true;
    }
}
