using System.ComponentModel.DataAnnotations;

namespace TableBooking.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
