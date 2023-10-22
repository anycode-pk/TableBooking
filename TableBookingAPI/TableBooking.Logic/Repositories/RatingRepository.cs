using TableBooking.Logic.Interfaces;
using TableBooking.Model;
using TableBooking.Model.Models;

namespace TableBooking.Logic.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(TableBookingContext context) : base(context)
        {
        }
    }
}
