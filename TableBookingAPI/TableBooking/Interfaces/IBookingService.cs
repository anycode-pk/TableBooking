using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface IBookingService
    {
        public Task<IActionResult> GetAllBookings(string userId);
        public Task<IActionResult> GetBookingByIdAsync(int bookingId, string userId);
        public Task<IActionResult> CreateBookingAsync(BookingToCreateDto dto, string userId);
        public Task<IActionResult> UpdateBookingAsync(BookingDTO dto);
        public Task<IActionResult> DeleteBookingAsync(int bookingId, string userId);
    }
}
