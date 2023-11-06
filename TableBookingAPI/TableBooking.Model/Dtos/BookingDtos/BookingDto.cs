using TableBooking.Model.Dtos.TableDtos;

namespace TableBooking.Model.Dtos.BookingDtos
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public TableDto TableDto { get; set; }
        public Guid UserId { get; set; }
    }
}
