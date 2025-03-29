
using BookingSystem.Application.DTOs.Create;
using BookingSystem.Application.Feature.Booking.Command;
using BookingSystem.Application.Feature.Booking.Handler;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastucture.Repository;
using Moq;
using System.Globalization;

namespace BookingSystem.Test;

public  class BookingTest
{
    [Fact]
    public async Task HandlerShouldReturnTrue()
    {
        var bookMock = new Mock<IBookingRepository>();
        var bookcreation = new CreateBookingModel()
        {
            BookingDate = DateTime.ParseExact("2024-07-23 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),

            BookingTime = TimeOnly.MinValue,
            ServiceId = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };
        var command = new CreateBookingCommand(bookcreation);
        var handler = new CreateBookingHandler(bookMock.Object);
        bookMock.Setup(repo => repo.AddAsync(It.IsAny<Booking>())).ReturnsAsync(new Booking());

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        bookMock.Verify(repo => repo.AddAsync(It.IsAny<Booking>()), Times.Once);

    }
    
}
