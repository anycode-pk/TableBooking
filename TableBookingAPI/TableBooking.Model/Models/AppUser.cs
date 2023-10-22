using Microsoft.AspNetCore.Identity;

namespace TableBooking.Model.Models
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}