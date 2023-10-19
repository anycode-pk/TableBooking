namespace TableBooking.Model
{
    public class Table : Entity
    {
        public int NumberOfSeats { get; set; }
        public Restaurant Restaurant { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
