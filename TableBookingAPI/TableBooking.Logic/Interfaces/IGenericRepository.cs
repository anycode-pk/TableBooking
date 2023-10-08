namespace TableBooking.Logic.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIDAsync(object id);
        public Task InsertAsync(T entity);
        public Task Delete(object id);
        public Task Update(T entity);
    }
}
