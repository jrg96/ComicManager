using ComicManager.Database.Data;
using ComicManager.Database.Entity;
using ComicManager.Database.Repository.Contract;

namespace ComicManager.Database.Repository
{
    public class ComicRepository : BaseRepository<Comic>, IComicRepository
    {
        public ComicRepository(ComicManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
