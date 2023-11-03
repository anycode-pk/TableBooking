namespace TableBooking.Model.Requests;

public class UpdateBookingRequest
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public Guid TableId { get; set; }
}
