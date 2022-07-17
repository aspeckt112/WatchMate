using System.Collections.Generic;
using System.Threading.Tasks;

namespace WatchMate.Shared.Services.Api;

interface IApiService
{
    Task<T> Get<T>(string endpoint, Dictionary<string, string> parameters) where T : class?;
}