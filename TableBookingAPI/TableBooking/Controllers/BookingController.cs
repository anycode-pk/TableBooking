using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableBooking.DTOs;
using TableBooking.EF;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private DataContext _context;
        public BookingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingsForCurrentUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound();

            var bookings = user.Bookings.ToList();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDTO> GetBooking([FromRoute] int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
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

        //[HttpPost]
        //public ActionResult<BookingDTO> AddBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        //{
        //    var booking = new Booking
        //    {
        //        Date = bookingToCreateDto.Date,
        //        Duration = bookingToCreateDto.BookingDuration,
        //        TableId = bookingToCreateDto.TableId,
        //        UserId = bookingToCreateDto.UserId
        //    };
        //    _context.Bookings.Add(booking);
        //    _context.SaveChanges();
        //    var bookingDto = new BookingDTO
        //    {
        //        Id = booking.Id,
        //        Date = booking.Date,
        //        BookingDuration = booking.Duration,
        //        TableId = booking.TableId,
        //        UserId = booking.UserId
        //    };
        //    return Created(string.Empty, bookingDto);
        //}

    }
}
