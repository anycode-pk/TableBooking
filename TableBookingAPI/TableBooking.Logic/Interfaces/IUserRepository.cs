using TableBooking.Model;

namespace TableBooking.Logic.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        public Task<IEnumerable<AppUser>> GetAllUsers();
        public Task<AppUser> GetUserById(string userId);
    }
}
