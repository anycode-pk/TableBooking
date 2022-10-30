using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TableBooking.Models;

public class Table
{
    public string? Id { get; set; }
    
    public int NumberOfSeats { get; set; }
}