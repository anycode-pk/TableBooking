namespace TableBooking.DTOs
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public TableDTO TableDto { get; set; }
        public Guid UserId { get; set; }
    }
}
