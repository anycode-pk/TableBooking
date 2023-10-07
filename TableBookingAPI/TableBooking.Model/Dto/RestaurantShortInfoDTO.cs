namespace TableBooking.DTOs;

public enum Price
{
    LOW,
    MEDIUM,
    HIGH
}

public class RestaurantShortInfoDTO
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string ImageURL { get; set; }
    public int Rating { get; set; }
    public Model.Price Price { get; set; }
    public DateTime OpenTime { get; set; }
    public DateTime CloseTime { get; set; }
}