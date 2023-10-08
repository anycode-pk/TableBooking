using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.DTOs;
using TableBooking.Model;

namespace TableBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(DataContext context, IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetBookings()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.GetAllBookings(userId);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.GetBookingByIdAsync(id, userId);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.DeleteBookingAsync(id, userId);
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _bookingService.CreateBookingAsync(bookingToCreateDto, userId);
        }

        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking()
        {
            return Ok();
        }

    }
}
