

using BookingSystem.Domain.Common;

namespace BookingSystem.Domain.Entity;

public  class Review : BaseEntity,IAuditedEntity
{
    public Guid UserID { get; set; }
    public Guid ServiceID { get; set; }
    public int Ratings { get; set; }    
    public string Comment { get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
