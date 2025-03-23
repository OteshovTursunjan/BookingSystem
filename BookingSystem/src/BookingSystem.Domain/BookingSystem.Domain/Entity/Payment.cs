
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enum;

namespace BookingSystem.Domain.Entity;

public  class Payment : BaseEntity,IAuditedEntity
{
    public Guid BookingID { get; set; }
    public int Amount { get; set; }
    public BookingStatus PaymentStatus { get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
