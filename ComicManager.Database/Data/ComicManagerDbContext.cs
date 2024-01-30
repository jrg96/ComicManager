using ComicManager.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ComicManager.Database.Data
{
    public class ComicManagerDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<CharacterComic> CharacterComics { get; set; }

        //OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        public ComicManagerDbContext(DbContextOptions<ComicManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterComic>()
                .HasOne<Character>(cc => cc.Character)
                .WithMany(c => c.CharacterComics)
                .HasForeignKey(cc => cc.CharacterId);

            modelBuilder.Entity<CharacterComic>()
                .HasOne<Comic>(cc => cc.Comic)
                .WithMany(c => c.CharacterComics)
                .HasForeignKey(cc => cc.ComicId);
        }
    }
}
