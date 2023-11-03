using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Model.Dtos.RatingDtos;

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

        [HttpPost("CreateRating")]
        public async Task<IActionResult> CreateRating([FromBody] CreateRatingDto createRatingDto)
        {
            return await _ratingService.CreateRatingAsync(createRatingDto);
        }
    }
}
