using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;
using ComicManager.Common.DTO.Response;

namespace ComicManager.UI.Common.Service.Contract
{
    public interface ICharacterService
    {
        Task<TaskResult<CharacterDTO>> GetCharacter(Guid id);
        Task<TaskResult<CharacterDTO>> CreateCharacter(CreateCharacterDTO createCharacterDTO);
        Task<TaskResult<PageDTO<CharacterDTO>>> GetCharacterList(GetCharacterListDTO getCharacterListDTO);
    }
}
