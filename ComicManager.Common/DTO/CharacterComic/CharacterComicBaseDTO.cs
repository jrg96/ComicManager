using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Comic;

namespace ComicManager.Common.DTO.CharacterComic
{
    public class CharacterComicBaseDTO
    {
        public CharacterDTO Character { get; set; }
        public ComicDTO Comic { get; set; }
    }
}
