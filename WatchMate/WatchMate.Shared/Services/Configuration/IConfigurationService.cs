using System.Threading.Tasks;

namespace WatchMate.Shared.Services.Configuration;

interface IConfigurationService
{
    bool ShouldCheckForConfigurationChanges();

    Task ReconcileConfiguration();

    string ImageBaseUrl { get; }

    string PosterImageSize { get; }
}