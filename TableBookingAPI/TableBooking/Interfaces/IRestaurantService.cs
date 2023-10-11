using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface IRestaurantService
    {
        public Task<IActionResult> GetAllRestaurantsAsync(string userId);
        public Task<IActionResult> GetRestaurantByIdAsync(int restaurantId);
        public Task<IActionResult> CreateRestaurantAsync(RestaurantShortInfoDTO dto);
        public Task<IActionResult> UpdateRestaurantAsync(RestaurantShortInfoDTO dto);
        public Task<IActionResult> DeleteRestaurantAsync(int restaurantId);
    }
}
