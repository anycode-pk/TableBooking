using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.DTOs;

namespace TableBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.GetAllBookings(userId);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.GetBookingByIdAsync(id, userId);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.DeleteBookingAsync(id, userId);
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.CreateBookingAsync(bookingToCreateDto, userId);
        }

        [HttpPut("UpdateBooking/{id}")]
        public async Task<IActionResult> UpdateBooking()
        {
            return Ok();
        }

    }
}
