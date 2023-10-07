using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableBooking.DTOs;
using TableBooking.EF;
using TableBooking.Model;

namespace TableBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private DataContext _context;
        public BookingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings(int? id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users
                    .Include(u => u.Bookings)
                    .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound();

            if (id != null)
            {
                var booking = user.Bookings.FirstOrDefault(b => b.Id == id);
                if (booking == null)
                    return NotFound();
                var bookingDto = new BookingDTO
                {
                    Id = booking.Id,
                    Date = booking.Date,
                    BookingDuration = booking.Duration,
                    TableId = booking.TableId,
                    UserId = booking.UserId
                };
                return Ok(bookingDto);
            }

            var bookingDtos = user.Bookings.Select(booking => new BookingDTO
            {
                Id = booking.Id,
                Date = booking.Date,
                BookingDuration = booking.Duration,
                TableId = booking.TableId,
                UserId = booking.UserId
            }).ToList();

            return Ok(bookingDtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
            if (booking == null)
                return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var table = _context.Tables.FindAsync(bookingToCreateDto.TableId);
            
            var newBooking = new Booking
            {
                Date = bookingToCreateDto.Date,
                Duration = bookingToCreateDto.BookingDuration,
                TableId = bookingToCreateDto.TableId,
                UserId = userId,
            };
            
            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            var bookingDto = new BookingDTO
            {
                Id = newBooking.Id,
                Date = newBooking.Date,
                BookingDuration = newBooking.Duration,
                TableId = newBooking.TableId,
                UserId = newBooking.UserId
            };

            return Created(String.Empty, bookingDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking()
        {
            return Ok();
        }

    }
}
