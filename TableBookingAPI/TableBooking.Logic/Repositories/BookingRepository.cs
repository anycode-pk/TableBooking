using Microsoft.EntityFrameworkCore;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Logic.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(TableBookingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsForSpecificUserAsync(Guid userId)
        {
            return await _objectSet.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Booking> GetBookingByIdForSpecificUserAsync(Guid bookingId, Guid userId)
        {
            return await _objectSet.FirstOrDefaultAsync(x => x.Id == bookingId && x.UserId.Equals(userId));
        }
    }
}
