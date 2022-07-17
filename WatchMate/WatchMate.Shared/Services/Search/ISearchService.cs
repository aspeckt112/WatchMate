using System.Threading.Tasks;
using WatchMate.Shared.Models;

namespace WatchMate.Shared.Services.Search;

interface ISearchService
{
    Task<SearchResultRoot> Search(string query);
}