using Microsoft.AspNetCore.Mvc;
using TableBooking.Models;
using TableBooking.Services;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService){
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<List<Restaurant>> Get() =>
            await _restaurantService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Restaurant>> Get(string id)
        {
            var book = await _restaurantService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
        {
            await _restaurantService.CreateAsync(restaurant);

            return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Restaurant updatedBook)
        {
            var book = await _restaurantService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _restaurantService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _restaurantService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _restaurantService.RemoveAsync(id);

            return NoContent();
        }
    }
}
