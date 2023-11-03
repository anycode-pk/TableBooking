using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Model.Dtos.RestaurantDtos;

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

        [HttpGet("GetAllRestaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            return await _restaurantService.GetAllRestaurantsAsync();
        }

        [HttpGet("GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById(Guid id)
        {
            return await _restaurantService.GetRestaurantByIdAsync(id);
        }

        [HttpPost("CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantShortInfoDto restaurantShortInfoDto)
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
