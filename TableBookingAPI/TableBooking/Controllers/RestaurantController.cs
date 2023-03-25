using Microsoft.AspNetCore.Mvc;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //private readonly IRestaurantRepository _restaurantRepository;

        //public RestaurantController(IRestaurantRepository restaurantRepository){
        //    _restaurantRepository = restaurantRepository;
        //}

        //[HttpGet]
        //public async Task<List<Restaurant>> Get() =>
        //    await _restaurantRepository.GetAsync();

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
