using System;
using System.Threading.Tasks;
using WatchMate.Shared.Models;
using WatchMate.Shared.Models.DisplayItems;
using WatchMate.Shared.Services.Configuration;
using WatchMate.Shared.Services.Images;
using WatchMate.Shared.Services.Search;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WatchMate.Shared.ViewModels
{
    internal class SearchPageViewModel : BaseViewModel
    {
        readonly INavigation _navigation;

        readonly ISearchService _searchService;

        readonly IImageService _imageService;

        public SearchPageViewModel(INavigation navigation, ISearchService searchService, IImageService imageService)
        {
            _navigation = navigation;
            _searchService = searchService;
            _imageService = imageService;
        }

        string? _searchTerm;

        public string? SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        ObservableRangeCollection<SearchResultDisplayItem> _searchResults = new();

        public ObservableRangeCollection<SearchResultDisplayItem> SearchResults
        {
            get => _searchResults;
            private set => SetProperty(ref _searchResults, value);
        }

        AsyncCommand? _searchCommand;

        public AsyncCommand SearchCommand =>
            _searchCommand ??= new AsyncCommand(OnSearchCommandExecuted, allowsMultipleExecutions: false);

        async Task OnSearchCommandExecuted()
        {
            try
            {
                var searchResultRoot = await _searchService.Search(SearchTerm!).ConfigureAwait(true);

                if (searchResultRoot.TotalResults == 0 || searchResultRoot.Results is null)
                {
                    return;
                }

                foreach (var searchResult in searchResultRoot.Results)
                {
                    SearchResults.Add(new SearchResultDisplayItem(_imageService, searchResult.PosterPath)
                    {
                        Title = searchResult.Title ?? searchResult.Name // TMDB Api will return title for a movie, or name for a show.
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}