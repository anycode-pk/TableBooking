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
    public string Phone { get; set; }
    public string? PrimaryImageURL { get; set; }
    public string? SecondaryImageURL { get; set; }
    public float Rating { get; set; }
    public Price Price { get; set; }
    public DateTime OpenTime { get; set; } 
    public DateTime CloseTime { get; set; }
    public IEnumerable<Table> Tables { get; set; }
}