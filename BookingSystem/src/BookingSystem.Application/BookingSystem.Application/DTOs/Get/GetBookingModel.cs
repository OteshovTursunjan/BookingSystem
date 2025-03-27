
namespace BookingSystem.Application.DTOs.Get;

public  class GetBookingModel
{
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime BookingDate { get; set; }  // Только дата (C# 10+)
    public TimeOnly BookingTime { get; set; }
    public BookingSystem.Domain.Enum.BookingStatus Status { get; set; } 
}
