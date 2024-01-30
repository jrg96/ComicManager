namespace ComicManager.Database.Repository.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<(IEnumerable<T> data, long total)> GetByFilter(int page, int size, Func<IQueryable<T>, IQueryable<T>> baseFilter);
        Task<T> GetByIdAsync(object id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> SaveAsync();
    }
}
