using Microsoft.EntityFrameworkCore;
using TableBooking.Model;

namespace TableBooking.Extentions;

public static class RestaurantExtentions
{
    public static IQueryable<Restaurant> Search(this DbSet<Restaurant> restaurants, string? search) 
    {
        if (search == null)
            return restaurants;
        
        return restaurants.Where(q => q.Name.Contains(search) || q.Type.Contains(search) || q.Location.Contains(search));
    }
}