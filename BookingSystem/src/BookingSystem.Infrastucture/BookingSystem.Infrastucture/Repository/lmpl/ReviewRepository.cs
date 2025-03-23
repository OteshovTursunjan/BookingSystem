using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastucture.Repository.lmpl;

public  class ReviewRepository : BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(DatabaseContext databaseContext) : base(databaseContext) { }
}
