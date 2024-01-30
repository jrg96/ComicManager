using ComicManager.BusinessLogic.Service;
using ComicManager.BusinessLogic.Service.Contract;
using ComicManager.Database.Repository;
using ComicManager.Database.Repository.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace ComicManager.BusinessLogic.Extension
{
    public class ServiceExtension
    {
        public static void AddServices(IServiceCollection Services)
        {
            Services.AddScoped<IComicRepository, ComicRepository>();
            Services.AddScoped<ICharacterRepository, CharacterRepository>();
            Services.AddScoped<ICharacterComicRepository, CharacterComicRepository>();

            Services.AddScoped<ICharacterService, CharacterService>();
            Services.AddScoped<IComicService, ComicService>();
        }
    }
}
