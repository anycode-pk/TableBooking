using TableBooking.Model;

namespace TableBooking.DTOs
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int BookingDuration { get; set; }
        public Guid TableId { get; set; }
        public string UserId { get; set; }
    }
}
