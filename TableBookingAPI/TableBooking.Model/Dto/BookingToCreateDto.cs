namespace TableBooking.DTOs
{
    public class BookingToCreateDto 
    {
        public DateTime Date { get; set; }
        public int BookingDuration { get; set; }
        public Guid TableId { get; set; }
        public Guid UserId { get; set; }
    }
}
