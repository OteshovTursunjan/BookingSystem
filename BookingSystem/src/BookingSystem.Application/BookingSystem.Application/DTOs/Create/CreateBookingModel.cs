

namespace BookingSystem.Application.DTOs.Create;

public  class CreateBookingModel
{
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime DateTime { get; set; }
}
