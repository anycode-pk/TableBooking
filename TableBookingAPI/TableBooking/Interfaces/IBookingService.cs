using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.Model.Requests;

namespace TableBooking.Api.Interfaces
{
    public interface IBookingService
    {
        public Task<IActionResult> GetAllBookings(string userId);
        public Task<IActionResult> GetBookingByIdAsync(Guid bookingId, string userId);
        public Task<IActionResult> CreateBookingAsync(CreateBookingRequest dto, string userId);
        public Task<IActionResult> UpdateBookingAsync(BookingDTO dto);
        public Task<IActionResult> DeleteBookingAsync(Guid bookingId, string userId);
    }
}
