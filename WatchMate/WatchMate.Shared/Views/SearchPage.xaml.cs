using WatchMate.Shared.Services.Configuration;
using WatchMate.Shared.Services.Images;
using WatchMate.Shared.Services.Search;
using WatchMate.Shared.ViewModels;

namespace WatchMate.Shared.Views
{
    public partial class SearchPage
    {

        SearchPageViewModel? _viewModel;

        SearchPageViewModel ViewModel => _viewModel ??= new SearchPageViewModel(
            navigation: Navigation,
            searchService: new SearchService(App.LazyApiService.Value),
            imageService: new ImageService(App.LazyApiService.Value, App.LazyConfigurationService.Value)
        );

        public SearchPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
    }
}