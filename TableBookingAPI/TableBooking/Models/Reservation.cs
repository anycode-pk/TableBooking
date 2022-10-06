using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TableBooking.Models;

public class Reservation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}