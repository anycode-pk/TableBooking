using TableBooking.Model;

namespace TableBooking.Logic.Interfaces
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        public Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
    }
}
