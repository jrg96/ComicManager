using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;

namespace ComicManager.BusinessLogic.Service.Contract
{
    public interface ICharacterService
    {
        Task<CharacterDTO> CreateCharacter(CreateCharacterDTO createCharacterDTO);
        Task<CharacterDTO> GetCharacterById(Guid id);
        Task<PageDTO<CharacterDTO>> GetCharacterList(GetCharacterListDTO getCharacterListDTO);
    }
}
