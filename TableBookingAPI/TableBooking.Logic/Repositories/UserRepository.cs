using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Logic.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _objectSet.Include(x => x.Bookings).ToListAsync();
        }

        public async Task<AppUser> GetUserById(string userId)
        {
            return await _objectSet.Include(x => x.Bookings).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
