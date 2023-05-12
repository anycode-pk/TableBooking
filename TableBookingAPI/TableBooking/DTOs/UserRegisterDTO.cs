using System.ComponentModel.DataAnnotations;

namespace TableBooking.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
