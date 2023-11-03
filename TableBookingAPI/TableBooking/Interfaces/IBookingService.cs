using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.Model.Requests;

namespace TableBooking.Api.Interfaces
{
    public interface IBookingService
    {
        public Task<IActionResult> GetAllBookings(Guid userId);
        public Task<IActionResult> GetBookingByIdAsync(Guid bookingId, Guid userId);
        public Task<IActionResult> CreateBookingAsync(CreateBookingRequest request, Guid userId);
        public Task<IActionResult> UpdateBookingAsync(UpdateBookingRequest request);
        public Task<IActionResult> DeleteBookingAsync(Guid bookingId, Guid userId);
    }
}
