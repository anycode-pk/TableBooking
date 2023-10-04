using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.EF;
using TableBooking.Model;

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
        public IActionResult GetAllBookings()
        {
            return Ok(_context.Bookings.ToList());
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

        [HttpPost]
        public ActionResult<BookingDTO> AddBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        {
            var booking = new Booking
            {
                Date = bookingToCreateDto.Date,
                Duration = bookingToCreateDto.BookingDuration,
                TableId = bookingToCreateDto.TableId,
                UserId = bookingToCreateDto.UserId
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            var bookingDto = new BookingDTO
            {
                Id = booking.Id,
                Date = booking.Date,
                BookingDuration = booking.Duration,
                TableId = booking.TableId,
                UserId = booking.UserId
            };
            return Created(string.Empty, bookingDto);
        }

    }
}
