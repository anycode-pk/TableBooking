﻿namespace TableBooking.Model.Dtos.RatingDtos
{
    public class CreateRatingDto
    {
        public int RatingStars { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfRating { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid AppUserId { get; set; }
    }
}
