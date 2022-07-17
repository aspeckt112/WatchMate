using System.Threading.Tasks;
using WatchMate.Shared.Models;
using WatchMate.Shared.Services.Api;

namespace WatchMate.Shared.Services.Search;

class SearchService : ISearchService
{
    readonly IApiService _apiService;

    const string MultiSearchEndpoint = "search/multi?";

    public SearchService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<SearchResultRoot> Search(string query)
    {
        var searchResultRoot = await _apiService.Get<SearchResultRoot>(MultiSearchEndpoint, new()
        {
            { "query", query }
        });

        // I should really add some error handling here.
        return searchResultRoot;
    }
}