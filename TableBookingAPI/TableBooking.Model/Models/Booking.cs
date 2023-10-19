namespace TableBooking.Model
{
    public class Booking : Entity
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Table Table { get; set; }
        public AppUser User { get; set; }
    }
}