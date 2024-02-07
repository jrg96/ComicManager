using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;
using ComicManager.Common.DTO.Response;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;


namespace ComicManager.UI.Common.Service
{
    public class CharacterService : BaseHttpClient, ICharacterService
    {
        private readonly string _controller;
        private readonly RestClient _restClient;

        public CharacterService(IConfiguration config) : base(config)
        {
            _controller = "Character";
            _restClient = new RestClient(BaseUrl);
        }

        public async Task<TaskResult<CharacterDTO>> CreateCharacter(CreateCharacterDTO createCharacterDTO)
        {
            RestRequest request = new RestRequest($"{_controller}");
            request.AddBody(createCharacterDTO, ContentType.Json);

            RestResponse response = await _restClient.PostAsync(request);
            TaskResult<CharacterDTO> data = null;

            if (response.IsSuccessStatusCode)
            {
                data = JsonSerializer.Deserialize<TaskResult<CharacterDTO>>(response.Content);
            }

            return data;
        }

        public async Task<TaskResult<CharacterDTO>> GetCharacter(Guid id)
        {
            RestRequest request = new RestRequest($"{_controller}/{id}");
            RestResponse<TaskResult<CharacterDTO>> response = await _restClient.ExecuteGetAsync<TaskResult<CharacterDTO>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }

            return null;
        }

        public async Task<TaskResult<PageDTO<CharacterDTO>>> GetCharacterList(GetCharacterListDTO getCharacterListDTO)
        {
            RestRequest request = new RestRequest($"{_controller}/List");
            request.AddBody(getCharacterListDTO, ContentType.Json);

            RestResponse<TaskResult<PageDTO<CharacterDTO>>> response = await _restClient.ExecutePostAsync<TaskResult<PageDTO<CharacterDTO>>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }

            return null;
        }

        public async Task<TaskResult<CharacterDTO>> UpdateCharacter(CharacterDTO characterDTO)
        {
            RestRequest request = new RestRequest($"{_controller}");
            request.AddBody(characterDTO, ContentType.Json);

            RestResponse<TaskResult<CharacterDTO>> response = await _restClient.ExecutePutAsync<TaskResult<CharacterDTO>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }

            return null;
        }
    }
}
