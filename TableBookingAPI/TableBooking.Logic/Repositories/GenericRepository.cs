using Microsoft.EntityFrameworkCore;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Logic.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TableBookingContext _context;
        protected readonly DbSet<T> _objectSet;

        public GenericRepository(TableBookingContext context)
        {
            _context = context;
            _objectSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _objectSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _objectSet.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
           await _objectSet.AddAsync(entity);
        }

        public async Task Delete(object id)
        {
            T entityToDelete = await _objectSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public async virtual Task Update(T entity)
        {
            Update(entity);
        }

    }
}
