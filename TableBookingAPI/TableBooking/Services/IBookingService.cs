using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Api.Services
{
    public interface IBookingService
    {
        public Task<IActionResult> GetAllBookings(Guid userId);
        public Task<IActionResult> GetBookingByIdAsync(Guid bookingId, Guid userId);
        public Task<IActionResult> CreateBookingAsync(BookingToCreateDto dto, Guid userId);
        public Task<IActionResult> UpdateBookingAsync(BookingDTO dto);
        public Task<IActionResult> DeleteBookingAsync(Guid bookingId, Guid userId);
    }
    public class BookingService : IBookingService
    {
        public IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> CreateBookingAsync(BookingToCreateDto dto, Guid userId)
        {
            var newBooking = new Booking
            {
                Date = dto.Date,
                Duration = dto.BookingDuration,
                TableId = dto.TableId,
                UserId = userId,
            };

            await _unitOfWork.BookingRepository.InsertAsync(newBooking);
            await _unitOfWork.SaveChangesAsync();

            var bookingDto = new BookingDTO
            {
                Id = newBooking.Id,
                Date = newBooking.Date,
                BookingDuration = newBooking.Duration,
                TableId = newBooking.TableId,
                UserId = newBooking.UserId
            };
            return new CreatedResult(String.Empty, bookingDto);
        }

        public async Task<IActionResult> DeleteBookingAsync(Guid bookingId, Guid userId)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdForSpecificUserAsync(bookingId, userId);
            if (booking == null)
                return new BadRequestObjectResult("Bad request");

            await _unitOfWork.BookingRepository.Delete(booking);
            await _unitOfWork.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IActionResult> GetBookingByIdAsync(Guid bookingId, Guid userId)
        {
            if (bookingId != null)
            {
                var booking = await _unitOfWork.BookingRepository.GetBookingByIdForSpecificUserAsync(bookingId, userId);
                if (booking == null)
                    return new BadRequestObjectResult("Bad request: no bookings");
                var bookingDto = new BookingDTO
                {
                    Id = booking.Id,
                    Date = booking.Date,
                    BookingDuration = booking.Duration,
                    TableId = booking.TableId,
                    UserId = booking.UserId
                };
                return new OkObjectResult(bookingDto);
            }
            return new BadRequestObjectResult("Bad request: no booking id");
        }

        public async Task<IActionResult> GetAllBookings(Guid userId)
        {
            var bookings = _unitOfWork.BookingRepository.GetAllBookingsForSpecificUserAsync(userId);
            if (bookings == null) return new BadRequestObjectResult("No bookings found");
            return new OkObjectResult(bookings);
        }

        public async Task<IActionResult> UpdateBookingAsync(BookingDTO dto)
        {
            return new OkObjectResult("XD");
        }
    }
}
