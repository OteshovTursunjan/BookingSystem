

using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;

namespace BookingSystem.Infrastucture.Repository.lmpl;

public  class PaymentRepository : BaseRepository<Payment>, IPayment
{
    public PaymentRepository(DatabaseContext databaseContext) : base(databaseContext) { }
}
