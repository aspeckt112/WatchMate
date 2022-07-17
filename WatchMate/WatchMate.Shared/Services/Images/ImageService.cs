using System.Threading.Tasks;
using WatchMate.Shared.Services.Api;
using WatchMate.Shared.Services.Configuration;

namespace WatchMate.Shared.Services.Images;

class ImageService : IImageService
{
    readonly IApiService _apiService;

    readonly IConfigurationService _configurationService;

    public ImageService(IApiService apiService, IConfigurationService configurationService)
    {
        _apiService = apiService;
        _configurationService = configurationService;
    }

    public Task<byte[]> GetImage(string url)
    {
        return _apiService.GetBytes(url);
    }

    public string ImageBaseUrl => _configurationService.ImageBaseUrl;

    public string PosterImageSize => _configurationService.PosterImageSize;
}