using System;
using System.Threading.Tasks;
using WatchMate.Shared.Services.Images;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WatchMate.Shared.Models.DisplayItems;

public class SearchResultDisplayItem : ObservableObject
{
    readonly IImageService _imageService;

    readonly Task _imageDownloadTask;

    public SearchResultDisplayItem(IImageService imageService, string posterPath)
    {
        _imageService = imageService;
        _imageDownloadTask = Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            // TODO Be smart and download the image, cache to disk.
            PosterImage =
                ImageSource.FromUri(
                    new Uri($"{imageService.ImageBaseUrl}/{imageService.PosterImageSize}/{posterPath}"));
        });
    }
    public string? Title { get; init; }

    ImageSource? _posterImage;
    public ImageSource? PosterImage
    {
        get => _posterImage;
        private set => SetProperty(ref _posterImage, value);
    }
}