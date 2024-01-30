using Microsoft.Extensions.Configuration;

namespace ComicManager.UI.Common.Service
{
    public class BaseHttpClient
    {
        protected string BaseUrl { get; set; }

        public BaseHttpClient(IConfiguration config)
        {
            BaseUrl = config["ApiBaseUrl"];
        }
    }
}
