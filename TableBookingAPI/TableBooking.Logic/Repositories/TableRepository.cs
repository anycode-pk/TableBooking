using TableBooking.Logic.Interfaces;
using TableBooking.Model;
using TableBooking.Model.Models;

namespace TableBooking.Logic.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        public TableRepository(TableBookingContext context) : base(context)
        {
        }
    }
}
