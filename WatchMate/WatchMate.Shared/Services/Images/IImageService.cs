using System.Threading.Tasks;

namespace WatchMate.Shared.Services.Images;

public interface IImageService
{
    Task<byte[]> GetImage(string url);

    string ImageBaseUrl { get; }

    string PosterImageSize { get; }
}