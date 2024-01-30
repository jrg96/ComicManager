using ComicManager.BusinessLogic.Service.Contract;
using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;
using ComicManager.Common.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace ComicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost("List")]
        public async Task<IActionResult> GetCharacterList([FromBody] GetCharacterListDTO getCharacterListDTO)
        {
            TaskResult<PageDTO<CharacterDTO>> result = new TaskResult<PageDTO<CharacterDTO>>();

            try
            {
                var data = await _characterService.GetCharacterList(getCharacterListDTO);

                result.Successfull = true;
                result.Data = data;
            }
            catch (Exception e)
            {
                result.Successfull = false;
                result.ErroList.Append("There was an error getting the character list: " + e.ToString());
            }

            return Ok(result);
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            TaskResult<CharacterDTO> result = new TaskResult<CharacterDTO>();

            try
            {
                var data = await _characterService.GetCharacterById(id);

                result.Successfull = true;
                result.Data = data;
            }
            catch (Exception e)
            {
                result.Successfull = false;
                result.ErroList.Append("There was an error getting the character: " + e.ToString());
            }

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDTO createCharacterDTO)
        {
            TaskResult<CharacterDTO> result = new TaskResult<CharacterDTO>();

            try
            {
                var data = await _characterService.CreateCharacter(createCharacterDTO);

                result.Successfull = true;
                result.Data = data;
            }
            catch(Exception e)
            {
                result.Successfull = false;
                result.ErroList.Append("There was an error creating the character: " + e.ToString());
            }

            return Ok(result);
        }
    }
}
