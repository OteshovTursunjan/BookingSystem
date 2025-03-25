
using BookingSystem.Domain.Enum;

namespace BookingSystem.Application.DTOs.Update
{
    public  class UpdateServiceModel
    {
        public Guid ProviderUserId { get; set; }


        public string? Name { get; set; }
        public  string? Description { get; set; }
        public int Price { get; set; }
    }
}
