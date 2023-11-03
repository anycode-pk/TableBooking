using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Api.Services;
using TableBooking.Model.Models;

namespace TableBooking.Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("GetAllRatings")]
        public async Task<IActionResult> GetRestaurants([FromQuery] Guid restuarantId)
        {
            return await _ratingService.GetAllRatingsAsync(restuarantId);
        }
    }
}
