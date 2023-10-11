namespace TableBooking.Model;

public enum Price
{
    LOW,
    MEDIUM,
    HIGH
}
public class Restaurant : Entity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public string? ImageURL { get; set; }
    public int Rating { get; set; }
    public Price Price { get; set; }
    public TimeSpan OpenTime { get; set; }
    public TimeSpan CloseTime { get; set; }
    public IEnumerable<Table> Tables { get; set; }
    
}