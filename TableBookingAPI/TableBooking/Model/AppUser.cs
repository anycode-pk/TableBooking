using Microsoft.AspNetCore.Identity;

namespace TableBooking.Model;


public class AppUser : IdentityUser
{
    public string? RefreshToken { get; set; }         
    public DateTime? RefreshTokenExpiryTime { get; set; } 
    public IEnumerable<Booking> Booking { get; set; }
}