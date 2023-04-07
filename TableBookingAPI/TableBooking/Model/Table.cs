namespace TableBooking.Model
{
    public class Table : Entity
    {
        public int NoSeats { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
