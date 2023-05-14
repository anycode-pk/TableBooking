namespace TableBooking.DTOs
{
    public class UserLoginResultDTO
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public TokenDTO Token { get; set; }
    }
}
