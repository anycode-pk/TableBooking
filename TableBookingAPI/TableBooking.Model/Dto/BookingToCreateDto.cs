using TableBooking.Model;

namespace TableBooking.DTOs
{
    public class BookingToCreateDto 
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Guid UserId { get; set; } 
        public Guid TableId { get; set; } 
    }
}