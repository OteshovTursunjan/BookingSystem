using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared;

public  interface IClaimService
{
    string GetUserId();
    string GetClaim(string key);
}
