using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Logic;
using TableBooking.Logic.Converters.RatingConverters;
using TableBooking.Logic.Interfaces;
using TableBooking.Model.Dtos.RatingDtos;

namespace TableBooking.Api.Services
{
    public class RatingService : IRatingService
    {
        private IUnitOfWork _unitOfWork;
        private IRatingConverter _ratingConverter;

        public RatingService(IUnitOfWork unitOfWork, IRatingConverter ratingConverter)
        { 
            _unitOfWork = unitOfWork;
            _ratingConverter = ratingConverter;
        }
        public async Task<IActionResult> CreateRatingAsync(CreateRatingDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteRatingAsync(Guid ratingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllRatingsAsync(Guid restaurantId)
        {
            var ratings = await _unitOfWork.RatingRepository.GetRatingsAsync(restaurantId);
            if (ratings == null) return new BadRequestObjectResult("No ratings found");
            var ratingDtos = _ratingConverter.RatingsToRatingDtos(ratings);
            return new OkObjectResult(ratingDtos);
        }

        public async Task<IActionResult> GetRatingByIdAsync(Guid ratingId)
        {
            throw new NotImplementedException();
        }
    }
}
