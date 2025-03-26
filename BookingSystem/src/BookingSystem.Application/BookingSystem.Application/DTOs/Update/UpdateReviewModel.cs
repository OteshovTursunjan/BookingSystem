

namespace BookingSystem.Application.DTOs.Update;

public  class UpdateReviewModel
{
    public Guid UserID { get; set; }
    public Guid ServiceID { get; set; }
  
    public string Comment { get; set; }
}
