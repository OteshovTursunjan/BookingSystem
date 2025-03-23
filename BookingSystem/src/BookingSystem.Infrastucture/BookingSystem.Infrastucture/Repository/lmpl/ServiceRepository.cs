
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;

namespace BookingSystem.Infrastucture.Repository.lmpl;

public  class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(DatabaseContext databaseContext) : base(databaseContext) { }
}
