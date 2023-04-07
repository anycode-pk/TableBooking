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
        public IActionResult GetAll()
        {
            return Ok(_context.Restaurants.ToList());
        }

        [HttpGet("/{id}")]
        public IActionResult GetById(int id)
        {
            var restaurant = _context.Restaurants.Find(id); // szukanie po primary key
            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            var restaurant = new Restaurant { Name = name };
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return Ok(restaurant);
        }

        [HttpDelete("{id:int}")] // kod nie powinien zwracac bledu
        public async Task<IActionResult> Delete(int id)
        {
            var restaurantToDelete = await _context.Restaurants.FindAsync(id);
            if (restaurantToDelete == null)
                return NotFound($"Restaurant with Id = {id} not found"); // zwraca 404
            _context.Restaurants.Remove(restaurantToDelete); // przenies do repozytorium
            await _context.SaveChangesAsync(); // metoda z EF
            return Ok(); // zwraca 200
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
