using System.Threading.Tasks;

namespace WatchMate.Shared.Services.Search;

interface ISearchService
{
    Task<SearchResultRoot> Search(string query);
}