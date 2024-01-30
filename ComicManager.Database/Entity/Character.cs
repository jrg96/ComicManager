using System.ComponentModel.DataAnnotations;

namespace ComicManager.Database.Entity
{
    public class Character
    {
        [Key]
        public Guid CharacterId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        /*
         * Navigation Properties
         */
        public IEnumerable<CharacterComic> CharacterComics { get; set; }
    }
}
