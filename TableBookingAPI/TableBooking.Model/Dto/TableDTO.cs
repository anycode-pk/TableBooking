using TableBooking.Model;

namespace TableBooking.DTOs;

public class TableDTO
{
    public int NumberOfSeats { get; set; }
    public Guid RestaurantId { get; set; }
    
}