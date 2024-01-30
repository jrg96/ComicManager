using ComicManager.Database.Data;
using ComicManager.Database.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace ComicManager.Database.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ComicManagerDbContext _dbContext;
        private DbSet<T> _dbSet;

        public BaseRepository(ComicManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<(IEnumerable<T> data, long total)> GetByFilter(int page, int size, Func<IQueryable<T>, IQueryable<T>> baseFilter)
        {
            IQueryable<T> query = _dbSet
                .Skip((page - 1) * size)
                .Take(size);
            query = baseFilter(query);

            return (await query.ToListAsync(), await query.LongCountAsync());
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
