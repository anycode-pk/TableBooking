using TableBooking.Model;

namespace TableBooking.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BookingDuration { get; set; }
        public int TableId { get; set; }
        public string UserId { get; set; }
    }
}
