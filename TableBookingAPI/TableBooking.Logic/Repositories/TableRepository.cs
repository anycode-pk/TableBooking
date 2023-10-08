using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Logic.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        public TableRepository(DataContext context) : base(context)
        {
        }
    }
}
