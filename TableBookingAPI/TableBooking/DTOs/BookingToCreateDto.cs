namespace TableBooking.DTOs
{
    public class BookingToCreateDto 
    {
        public DateTime Date { get; set; }
        public int BookingDuration { get; set; }
        public int TableId { get; set; }
        public string UserId { get; set; }
    }
}
