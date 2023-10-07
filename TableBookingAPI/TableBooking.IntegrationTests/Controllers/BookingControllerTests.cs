namespace TableBooking.IntegrationTests.Controllers;

using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TableBooking.Model;

public class BookingControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BookingControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(1)]
    public async Task GetBookingById_WhenCalled_ReturnBooking(int id)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"booking/{id}");
        Assert.True(response.IsSuccessStatusCode);

        var rawResponseData = await response.Content.ReadAsStringAsync();
        var booking = JsonConvert.DeserializeObject<Booking>(rawResponseData);

        Assert.NotNull(booking);
    }
}

