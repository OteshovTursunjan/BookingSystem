
namespace BookingSystem.Application.DTOs.Create;

public  class CreateReviewModel
{
    public Guid UserID { get; set; }
    public Guid ServiceID { get; set; }
    public Rating Ratings { get; set; }
    public string Comment { get; set; }
}

   public enum Rating
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5
}
