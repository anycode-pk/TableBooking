using Google.Cloud.Firestore;
using Microsoft.Extensions.Options;
using TableBooking.Interfaces;
using TableBooking.Models;

namespace TableBooking.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly CollectionReference restaurantCollection;
    public RestaurantRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var db = FirestoreDb.Create(databaseSettings.Value.ProjectId);

        restaurantCollection = db.Collection(databaseSettings.Value.ProjectId);
    }
    
    public async Task<List<Restaurant>> GetAsync()
    {
        var restaurants = new List<Restaurant>();
        Query query = restaurantCollection;
        QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
        foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
        {
            Dictionary<string, object> dictionary = documentSnapshot.ToDictionary();
            var name = "";
            var type = "";
            if (dictionary.ContainsKey("name"))
            {
                if (dictionary.TryGetValue("name", out var result))
                {
                    name = result.ToString();
                }
            }
            if (dictionary.ContainsKey("type"))
            {
                if (dictionary.TryGetValue("type", out var result))
                {
                    type = result.ToString();
                }
            }
            var restaurant = new Restaurant
            {
                Id = documentSnapshot.Id,
                Name = name,
                Type = type
            };
            restaurants.Add(restaurant);
        }

        return restaurants;
    }

    public async Task<Restaurant?> GetAsync(string id)
    {
        var document = restaurantCollection.Document(id);
        var snapshot = await document.GetSnapshotAsync(); // tutaj gdzies nie powinno byc query ? wyzej jest
        if (snapshot.Exists)
        {
            Dictionary<string, object> dictionary = snapshot.ToDictionary();
            var name = "";
            var type = "";
            if (dictionary.ContainsKey("name"))
            {
                if (dictionary.TryGetValue("name", out var result))
                {
                    name = result.ToString();
                }
            }
            if (dictionary.ContainsKey("type"))
            {
                if (dictionary.TryGetValue("type", out var result))
                {
                    type = result.ToString();
                }
            }
            var restaurant = new Restaurant
            {
                Id = snapshot.Id,
                Name = name,
                Type = type
            };
            return restaurant;
        }

        return new Restaurant();
    }

    public async Task CreateAsync(Restaurant restaurant)
    {
        var documentReference = restaurantCollection.Document(restaurant.ToString()); // dobry path?
        var restaurant1 = new Dictionary<string, object>
        {
            { "Id"  , restaurant.Id   },
            { "name", restaurant.Name },
            { "type", restaurant.Type }
        };
        await documentReference.SetAsync(restaurant1);
    }

    public async Task UpdateAsync(string id, Restaurant updatedBook)
    {
        var bookReference = restaurantCollection.Document(id);
        var updateBook = new Dictionary<string, object>
        {
            { "Id", id }
        };
        await bookReference.UpdateAsync("Id", id);
    }

    public async Task RemoveAsync(string id) // nie usuwa subkolekcji usunietej kolekcji
    {
        DocumentReference idRef = restaurantCollection.Document(id);
        await idRef.DeleteAsync();
    }
}