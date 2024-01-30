using ComicManager.Database.Data;
using ComicManager.Database.Entity;
using ComicManager.Database.Repository.Contract;

namespace ComicManager.Database.Repository
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ComicManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
