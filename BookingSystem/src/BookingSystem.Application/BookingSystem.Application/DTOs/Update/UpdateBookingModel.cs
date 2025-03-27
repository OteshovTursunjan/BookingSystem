using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTOs.Update
{
    public  class UpdateBookingModel
    {
       public Guid id { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
