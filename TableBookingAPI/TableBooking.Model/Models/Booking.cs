namespace TableBooking.Model
{
    public class Booking : Entity
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Table Table { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
    }
}