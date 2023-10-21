using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.DTOs;
using TableBooking.Logic.Converters.Table;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Api.Services
{
    public class BookingService : IBookingService
    {
        public IUnitOfWork _unitOfWork;
        private readonly ITableConverter _tableConverter;

        public BookingService(IUnitOfWork unitOfWork, ITableConverter tableConverter)
        {
            _unitOfWork = unitOfWork;
            _tableConverter = tableConverter;
        }
        public async Task<IActionResult> CreateBookingAsync(BookingToCreateDto dto, string userId)
        {
            var newBooking = new Booking
            {
                Date = dto.Date,
                DurationInMinutes = dto.DurationInMinutes,
                TableId = dto.TableId,
                UserId = dto.UserId
            };


        await _unitOfWork.BookingRepository.InsertAsync(newBooking);
            await _unitOfWork.SaveChangesAsync();

            var bookingDto = new BookingDTO
            {
                Id = newBooking.Id,
                Date = newBooking.Date,
                DurationInMinutes = newBooking.DurationInMinutes,
                TableDto = _tableConverter.TableToTableDto(newBooking.Table),
                UserId = newBooking.User.Id
            };
            return new CreatedResult(String.Empty, bookingDto);
        }

        public async Task<IActionResult> DeleteBookingAsync(Guid bookingId, string userId)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdForSpecificUserAsync(bookingId, userId);
            if (booking == null)
                return new BadRequestObjectResult("Bad request");

            await _unitOfWork.BookingRepository.Delete(booking);
            await _unitOfWork.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IActionResult> GetBookingByIdAsync(Guid bookingId, string userId)
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
                    DurationInMinutes = booking.DurationInMinutes,
                    TableDto = _tableConverter.TableToTableDto(booking.Table),
                    UserId = booking.User.Id
                };
                return new OkObjectResult(bookingDto);
            }
            return new BadRequestObjectResult("Bad request: no booking id");
        }

        private TableDTO ToModel(Table table)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllBookings(string userId)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllBookingsForSpecificUserAsync(userId);
            if (bookings == null) return new BadRequestObjectResult("No bookings found");
            return new OkObjectResult(bookings);
        }

        public async Task<IActionResult> UpdateBookingAsync(BookingDTO dto)
        {
            return new OkObjectResult("XD");
        }
    }
}
