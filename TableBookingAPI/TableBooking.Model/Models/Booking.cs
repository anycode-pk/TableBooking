namespace TableBooking.Model.Models
{
    public class Booking : Entity
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Table Table { get; set; }
        public Guid AppUserId { get; set; }
        public Guid TableId { get; set; }
    }
}