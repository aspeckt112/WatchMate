using System.Collections.Generic;
using System.Threading.Tasks;

namespace WatchMate.Shared.Services.Api;

interface IApiService
{
    Task<T> Get<T>(string endpoint, Dictionary<string, string>? parameters = null) where T : class?;

    Task<byte[]> GetBytes(string endpoint);
}