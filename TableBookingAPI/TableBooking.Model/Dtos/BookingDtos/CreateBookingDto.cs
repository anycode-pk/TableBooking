namespace TableBooking.Model.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public Guid TableId { get; set; }
    }
}