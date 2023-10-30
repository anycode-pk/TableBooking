using TableBooking.Model.Models;

namespace TableBooking.Logic.Extensions
{
    public static class RestaurantExtension
    {
        public static IQueryable<Restaurant> FilterByName(this IQueryable<Restaurant> restaurant, string? name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return restaurant;
            }
            return restaurant.Where(x => x.Name.StartsWith(name));
        }
    }
}
