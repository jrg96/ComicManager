using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicManager.Database.Entity
{
    public class CharacterComic
    {
        [Key]
        public Guid CharacterComicId { get; set; }

        [ForeignKey("Character")]
        public Guid CharacterId { get; set; }
        [ForeignKey("Comic")]
        public Guid ComicId { get; set; }

        /*
         * Navigation properties
         */
        public Character Character { get; set; }
        public Comic Comic { get; set; }
    }
}
