using Microsoft.AspNetCore.Mvc;
using TableBooking.EF;
using TableBooking.Model;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private DataContext _context;
        public RestaurantController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _context.Restaurants.ToList();
            return Ok(restaurants);
        }

        [HttpGet("/{id}")]
        public IActionResult GetById(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            var restaurant = new Restaurant { Name = name };
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
        
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Restaurant>> Get(string id)
        //{
        //    var book = await _restaurantRepository.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
        //{
        //    await _restaurantRepository.CreateAsync(restaurant);

        //    return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(string id, [FromBody] Restaurant updatedBook)
        //{
        //    var book = await _restaurantRepository.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    updatedBook.Id = book.Id;
        //    await _restaurantRepository.UpdateAsync(id, updatedBook);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var book = await _restaurantRepository.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }
        //    await _restaurantRepository.RemoveAsync(id);
        //    return NoContent();
        //}
    }
}
