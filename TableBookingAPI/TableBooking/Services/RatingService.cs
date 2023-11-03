using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Logic.Converters.RatingConverters;
using TableBooking.Logic.Interfaces;
using TableBooking.Model.Dtos.RatingDtos;
using TableBooking.Model.Models;

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
            var user = await _unitOfWork.UserRepository.GetByIdAsync(dto.AppUserId);
            var restaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(dto.RestaurantId);
            if (user == null || restaurant == null) return new BadRequestObjectResult(string.Empty);

            var rating = new Rating
            {
                RatingStars = dto.RatingStars,
                Comment = dto.Comment,
                DateOfRating = dto.DateOfRating,
                RestaurantId = dto.RestaurantId,
                AppUserId = dto.AppUserId
            };

            await _unitOfWork.RatingRepository.InsertAsync(rating);
            await _unitOfWork.SaveChangesAsync();
            return new OkObjectResult(_ratingConverter.RatingToRatingDto(rating));
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
