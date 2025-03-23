﻿

using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BookingSystem.Shared;

public  class ClaimService : IClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetUserId()
    {
        return GetClaim(ClaimTypes.NameIdentifier);
    }
    public string GetClaim(string key)
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value;
    }
}
