namespace TableBooking.Model.Dto
{
    public class RatingDTO
    {
        public Guid Id { get; set; }
        public int RatingStars { get; set; }
        public int NumberOfLikes { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfRating { get; set; }
        public Guid RestaurantId { get; set; }
        public string AppUserId { get; set; }
    }
}
