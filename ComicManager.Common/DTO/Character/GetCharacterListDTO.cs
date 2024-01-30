using ComicManager.Common.DTO.Request;

namespace ComicManager.Common.DTO.Character
{
    public class GetCharacterListDTO
    {
        public PageDTO<CharacterDTO> Page { get; set; }
    }
}
