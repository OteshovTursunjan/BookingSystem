using BookingSystem.Domain.Enum;
using System;
namespace BookingSystem.Application.DTOs.Get;

public  class GetServiceModel
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Price { get; set; }
    public Categories Categories { get; set; }
}
