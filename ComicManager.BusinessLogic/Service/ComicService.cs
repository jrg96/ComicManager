using AutoMapper;
using ComicManager.BusinessLogic.Service.Contract;
using ComicManager.Common.DTO.Comic;
using ComicManager.Database.Entity;
using ComicManager.Database.Repository.Contract;

namespace ComicManager.BusinessLogic.Service
{
    public class ComicService : IComicService
    {
        private readonly IComicRepository _comicRepository;
        private readonly IMapper _mapper;

        public ComicService(IComicRepository comicRepository, IMapper mapper)
        {
            _comicRepository = comicRepository;
            _mapper = mapper;
        }

        public async Task<ComicDTO> CreateComic(CreateComicDTO createComicDTO)
        {
            Comic comic = await _comicRepository.InsertAsync(_mapper.Map<Comic>(createComicDTO));
            return _mapper.Map<Comic, ComicDTO>(comic);
        }

        public async Task<ComicDTO> GetComicById(Guid id)
        {
            Comic comic = await _comicRepository.GetByIdAsync(id);
            return _mapper.Map<Comic, ComicDTO>(comic);
        }
    }
}
