namespace TableBooking.Model.Requests
{
    public class CreateBookingRequest
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Guid TableId { get; set; }
    }
}