
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enum;

namespace BookingSystem.Domain.Entity;

public  class Booking : BaseEntity, IAuditedEntity
{
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime DateTime { get; set; }
    public BookingStatus BookingStatus { get; set; }    
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
