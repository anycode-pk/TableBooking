using TableBooking.Models;

namespace TableBooking.Interfaces;

public interface IRestaurantRepository
{
    Task<List<Restaurant>> GetAsync();
    Task<Restaurant?> GetAsync(string id);
    Task CreateAsync(Restaurant restaurant);
    Task UpdateAsync(string id, Restaurant updatedBook);
    Task RemoveAsync(string id);
}