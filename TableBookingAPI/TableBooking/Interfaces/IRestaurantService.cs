using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface IRestaurantService
    {
        public Task<IActionResult> GetAllRestaurantsAsync();
        public Task<IActionResult> GetRestaurantByIdAsync(Guid restaurantId);
        public Task<IActionResult> CreateRestaurantAsync(RestaurantShortInfoDto dto);
        public Task<IActionResult> UpdateRestaurantAsync(RestaurantShortInfoDto dto);
        public Task<IActionResult> DeleteRestaurantAsync(Guid restaurantId);
    }

}
