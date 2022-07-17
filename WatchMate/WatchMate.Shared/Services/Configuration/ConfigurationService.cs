using System;
using System.Linq;
using System.Threading.Tasks;
using WatchMate.Shared.Services.Api;
using Xamarin.Essentials;

namespace WatchMate.Shared.Services.Configuration;

class ConfigurationService : IConfigurationService
{
    readonly IApiService _apiService;

    const string PreviousConfigFetchTimeKey = "previous_confing_fetch_time";

    const string ImageBaseUrlKey = "image_base_url";

    const string PosterImageSizeKey = "poster_image_size";

    public ConfigurationService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public bool ShouldCheckForConfigurationChanges()
    {
#if DEBUG
        return false; // In debug, only check for config changes when forced.
#else
        throw new NotImplementedException();
#endif
    }

    public  Task ReconcileConfiguration()
    {
        if (!ShouldCheckForConfigurationChanges()) return Task.CompletedTask;

        return Task.Run(async () =>
        {
            var configuration = await _apiService.Get<ConfigurationRoot>("configuration").ConfigureAwait(false);
            if (configuration is null || configuration.ImageInformation is null) return;
            ImageBaseUrl = configuration.ImageInformation.SecureBaseUrl;
            // TODO Make sure this can't be null when sent from the API
            PosterImageSize = configuration.ImageInformation.PosterSizes.First(x => x == "w500");
            Preferences.Set(PreviousConfigFetchTimeKey, DateTime.Now.Ticks);
        });
    }

    public string ImageBaseUrl
    {
        get => Preferences.Get(ImageBaseUrlKey, string.Empty);
        private set => Preferences.Set(ImageBaseUrlKey, value);
    }

    public string PosterImageSize
    {
        get => Preferences.Get(PosterImageSizeKey, null) ?? "original";
        private set => Preferences.Set(PosterImageSizeKey, value);
    }
}