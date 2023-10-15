using TableBooking.Model;

namespace TableBooking.Logic.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        public Task<IEnumerable<Booking>> GetAllBookingsForSpecificUserAsync(Guid userId);
        public Task<Booking> GetBookingByIdForSpecificUserAsync(Guid bookingId, Guid userId);
    }
}
