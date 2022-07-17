using WatchMate.Shared.Services.Search;
using WatchMate.Shared.ViewModels;

namespace WatchMate.Shared.Views
{
    public partial class SearchPage
    {

        SearchPageViewModel? _viewModel;

        SearchPageViewModel ViewModel => _viewModel ??= new SearchPageViewModel(
            navigation: Navigation,
            searchService: new SearchService(App.LazyApiService.Value)
        );

        public SearchPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
    }
}