using ComicManager.Common.DTO.Comic;

namespace ComicManager.BusinessLogic.Service.Contract
{
    public interface IComicService
    {
        Task<ComicDTO> GetComicById(Guid id);
        Task<ComicDTO> CreateComic(CreateComicDTO createComicDTO);
    }
}
