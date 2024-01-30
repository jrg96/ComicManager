using ComicManager.Database.Data;
using ComicManager.Database.Entity;
using ComicManager.Database.Repository.Contract;

namespace ComicManager.Database.Repository
{
    public class CharacterComicRepository : BaseRepository<CharacterComic>, ICharacterComicRepository

    {
        public CharacterComicRepository(ComicManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
