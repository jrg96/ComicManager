using AutoMapper;
using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Comic;
using ComicManager.Database.Entity;

namespace ComicManager.API.Configuration
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Character, CharacterDTO>();
            CreateMap<CreateCharacterDTO, Character>();
            CreateMap<CharacterDTO, Character>();

            CreateMap<Comic, ComicDTO>();
            CreateMap<CreateComicDTO, Comic>();
        }
    }
}
