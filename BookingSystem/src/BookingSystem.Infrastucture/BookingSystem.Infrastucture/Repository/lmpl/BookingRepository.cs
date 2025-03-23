
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BookingSystem.Infrastucture.Repository.lmpl;

public  class BookingRepository : BaseRepository<Booking> , IBookingRepository
{
    public BookingRepository(DatabaseContext DatabaseContext) : base(DatabaseContext) { }
}
