using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TableBooking.Models;

namespace TableBooking.Services;

public class RestaurantService
{
    private readonly IMongoCollection<Restaurant> _restaurantCollection;

    public RestaurantService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _restaurantCollection = mongoDatabase.GetCollection<Restaurant>(
            databaseSettings.Value.CollectionName);
    }

    public async Task<List<Restaurant>> GetAsync()
    {
        return await _restaurantCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Restaurant?> GetAsync(string id)
    {
        FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq("Id", id);
        return await _restaurantCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Restaurant restaurant)
    {
        await _restaurantCollection.InsertOneAsync(restaurant);
    }

    public async Task UpdateAsync(string id, Restaurant updatedBook)
    {
        FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq("Id", id);
        await _restaurantCollection.ReplaceOneAsync(filter, updatedBook);
    }

    public async Task RemoveAsync(string id)
    {
        FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq("Id", id);
        await _restaurantCollection.DeleteOneAsync(filter);
    }
}