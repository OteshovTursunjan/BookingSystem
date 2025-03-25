using BookingSystem.Domain.Enum;
namespace BookingSystem.Application.DTOs.Create;
public  class CreateServiceModel
{
    public Guid ProviderUserId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Price { get; set; }
    public Categories Categories { get; set; }
}
