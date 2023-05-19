using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.EF;
using TableBooking.Extentions;
using TableBooking.Model;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DataContext _context;
        public RestaurantController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SearchRestaurants(string? search)
        {
            var restaurantsSearched = _context.Restaurants.Search(search).ToList();
            return Ok(restaurantsSearched);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RestaurantShortInfoDTO restaurantShortInfoDto)
        {
            var restaurant = new Restaurant
            {
                Name = restaurantShortInfoDto.Name,
                CloseTime = restaurantShortInfoDto.CloseTime,
                Description = restaurantShortInfoDto.Description,
                Location = restaurantShortInfoDto.Location,
                Rating = 0,
                Price = restaurantShortInfoDto.Price,
                OpenTime = restaurantShortInfoDto.OpenTime,
                Type = restaurantShortInfoDto.Type
            };
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurantToDelete = await _context.Restaurants.FindAsync(id);
            if (restaurantToDelete == null)
                return NotFound($"Restaurant with Id = {id} not found");
            _context.Restaurants.Remove(restaurantToDelete);
            await _context.SaveChangesAsync();
            return Ok(restaurantToDelete);
        }


    }
}
