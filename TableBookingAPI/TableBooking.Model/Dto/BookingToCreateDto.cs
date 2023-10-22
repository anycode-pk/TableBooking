namespace TableBooking.DTOs
{
    public class BookingToCreateDto 
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public string UserId { get; set; } 
        public Guid TableId { get; set; } 
    }
}