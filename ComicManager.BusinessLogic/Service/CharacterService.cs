using AutoMapper;
using ComicManager.BusinessLogic.Service.Contract;
using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;
using ComicManager.Common.Enum;
using ComicManager.Database.Entity;
using ComicManager.Database.Repository.Contract;

namespace ComicManager.BusinessLogic.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;

        }
        public async Task<CharacterDTO> CreateCharacter(CreateCharacterDTO createCharacterDTO)
        {
            Character character = await _characterRepository.InsertAsync(_mapper.Map<Character>(createCharacterDTO));
            await _characterRepository.SaveAsync();
            return _mapper.Map<Character, CharacterDTO>(character);
        }

        public async Task<CharacterDTO> GetCharacterById(Guid id)
        {
            Character character = await _characterRepository.GetByIdAsync(id);
            return _mapper.Map<Character, CharacterDTO>(character);
        }

        public async Task<PageDTO<CharacterDTO>> GetCharacterList(GetCharacterListDTO getCharacterListDTO)
        {
            PageDTO<CharacterDTO> pageDTO = getCharacterListDTO.Page;

            (IEnumerable<Character> data, long totalCount) = await _characterRepository.GetByFilter(
                pageDTO.Number, 
                pageDTO.Size,
                (IQueryable<Character> data) => {
                    switch(pageDTO.Sorting)
                    {
                        case SortModeEnum.Ascending:
                            data = data.OrderBy(character => character.Name);
                            break;

                        case SortModeEnum.Descending:
                            data = data.OrderByDescending(character => character.Name);
                            break;
                    }

                    return data; 
                }
            );

            return new PageDTO<CharacterDTO>()
            {
                Number = pageDTO.Number,
                Size = pageDTO.Size,
                TotalRecords = totalCount,
                Sorting = pageDTO.Sorting,
                Data = data.Select(character => _mapper.Map<CharacterDTO>(character)).ToList()
            };
        }

        public async Task<CharacterDTO> UpdateCharacter(CharacterDTO characterDTO)
        {
            Character character = _mapper.Map<Character>(characterDTO);
            await _characterRepository.UpdateAsync(character);
            await _characterRepository.SaveAsync();
            return characterDTO;
        }
    }
}
