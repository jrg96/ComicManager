using System.ComponentModel.DataAnnotations;

namespace ComicManager.Database.Entity
{
    public class Comic
    {
        [Key]
        public Guid ComicId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        /*
         * Navigation Properties
         */
        public IEnumerable<CharacterComic> CharacterComics { get; set; }
    }
}
