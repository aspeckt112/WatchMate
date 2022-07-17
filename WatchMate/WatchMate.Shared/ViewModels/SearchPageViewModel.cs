using System;
using System.Threading.Tasks;
using WatchMate.Shared.Services.Search;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WatchMate.Shared.ViewModels
{
    internal class SearchPageViewModel : BaseViewModel
    {
        readonly INavigation _navigation;

        readonly ISearchService _searchService;

        public SearchPageViewModel(INavigation navigation, ISearchService searchService)
        {
            _navigation = navigation;
            _searchService = searchService;
        }


        string? _searchTerm;

        public string? SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        AsyncCommand? _searchCommand;

        public AsyncCommand SearchCommand =>
            _searchCommand ??= new AsyncCommand(OnSearchCommandExecuted, allowsMultipleExecutions: false);

        async Task OnSearchCommandExecuted()
        {
            var searchResultRoot = await _searchService.Search(SearchTerm!).ConfigureAwait(true);

            if (searchResultRoot.TotalResults == 0)
            {
                return;
            }

            App.Current.MainPage.DisplayAlert("Working?", "Working?", "OK");

        }
    }
}