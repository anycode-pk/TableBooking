namespace TableBooking.Model
{
    public class Booking : Entity
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
