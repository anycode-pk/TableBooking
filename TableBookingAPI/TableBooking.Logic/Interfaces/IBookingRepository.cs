using TableBooking.Model;

namespace TableBooking.Logic.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        public Task<IEnumerable<Booking>> GetAllBookingsForSpecificUserAsync(string userId);
        public Task<Booking> GetBookingByIdForSpecificUserAsync(Guid bookingId, string userId);
    }
}
