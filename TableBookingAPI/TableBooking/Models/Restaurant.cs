using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TableBooking.Models;

public class Restaurant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; }
    
    public string Image { get; set; }

    public string Type { get; set; }
    
    public List<Table> Tables { get; set; }
}