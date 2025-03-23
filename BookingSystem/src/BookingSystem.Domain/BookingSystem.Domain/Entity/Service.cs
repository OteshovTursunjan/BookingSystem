
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enum;

namespace BookingSystem.Domain.Entity;

public class Service : BaseEntity, IAuditedEntity
{
    public Guid ProviderUserId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Price { get; set; }
    public Categories Categories { get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
