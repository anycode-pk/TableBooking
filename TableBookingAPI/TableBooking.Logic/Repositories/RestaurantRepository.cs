using Microsoft.EntityFrameworkCore;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;
using TableBooking.Model.Models;

namespace TableBooking.Logic.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(TableBookingContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            return await _objectSet.ToListAsync();
        }
    }
}
