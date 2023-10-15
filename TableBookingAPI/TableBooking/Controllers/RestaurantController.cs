using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Services;
using TableBooking.DTOs;

namespace TableBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("GetRestaurants")]
        public async Task<IActionResult> GetRestaurants([FromBody]string? search)
        {
            return await _restaurantService.GetAllRestaurantsAsync(search);
        }

        [HttpGet("GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById(Guid id)
        {
            return await _restaurantService.GetRestaurantByIdAsync(id);
        }

        [HttpPost("CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantShortInfoDTO restaurantShortInfoDto)
        {
            return await _restaurantService.CreateRestaurantAsync(restaurantShortInfoDto);
        }

        [HttpDelete("DeleteRestaurant/{id:int}")]
        public async Task<IActionResult> DeleteRestaurant(Guid id)
        {
            return await _restaurantService.DeleteRestaurantAsync(id);
        }

        [HttpPut("UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurant()
        {
            return Ok();
        }


    }
}
