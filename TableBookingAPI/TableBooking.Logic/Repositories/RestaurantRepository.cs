using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.Logic.Extensions;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Logic.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync(string? restaurantName)
        {
            return await _objectSet.FilterByName(restaurantName).ToListAsync();
        }
    }
}
