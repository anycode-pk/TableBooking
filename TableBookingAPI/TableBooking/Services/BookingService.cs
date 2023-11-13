using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Logic.Converters.TableConverters;
using TableBooking.Logic.Interfaces;
using TableBooking.Model.Dtos.BookingDtos;
using TableBooking.Model.Models;

namespace TableBooking.Api.Services
{
    public class BookingService : IBookingService
    {
        public IUnitOfWork _unitOfWork;
        private readonly ITableConverter _tableConverter;
        private readonly ITableService _tableService;


        public BookingService(IUnitOfWork unitOfWork, ITableConverter tableConverter, ITableService tableService)
        {
            _unitOfWork = unitOfWork;
            _tableConverter = tableConverter;
            _tableService = tableService;
        }
        public async Task<IActionResult> CreateBookingAsync(CreateBookingDto request, Guid userId)
        {
            var table = await _tableService.GetTableObjectByIdAsync(request.TableId);
            
            var newBooking = new Booking
            {
                Date = request.Date,
                DurationInMinutes = request.DurationInMinutes,
                TableId = request.TableId,
                AppUserId = userId,
                Table = table
            };

            await _unitOfWork.BookingRepository.InsertAsync(newBooking);
            await _unitOfWork.SaveChangesAsync();

            var bookingDto = new BookingDto
            {
                Id = newBooking.Id,
                Date = newBooking.Date,
                DurationInMinutes = newBooking.DurationInMinutes,
                TableDto = _tableConverter.TableToTableDto(newBooking.Table),
                UserId = userId
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
                var bookingDto = new BookingDto
                {
                    Id = booking.Id,
                    Date = booking.Date,
                    DurationInMinutes = booking.DurationInMinutes,
                    TableDto = _tableConverter.TableToTableDto(booking.Table),
                    UserId = userId
                };
                return new OkObjectResult(bookingDto);
            }
            return new BadRequestObjectResult("Bad request: no booking id");
        }

        public async Task<IActionResult> GetAllBookings(Guid userId)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllBookingsForSpecificUserAsync(userId);
            if (bookings == null) return new BadRequestObjectResult("No bookings found");
            return new OkObjectResult(bookings);
        }

        public async Task<IActionResult> UpdateBookingAsync(UpdateBookingDto updateBookingDto, Guid userId)
        {
            return new OkObjectResult("XD");
        }
    }
}
