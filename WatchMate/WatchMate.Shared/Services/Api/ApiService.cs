using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using WatchMate.Shared.Resources.Strings;

namespace WatchMate.Shared.Services.Api;

class ApiService : IApiService
{
    readonly HttpClient _httpClient;

    public ApiService(HttpClientHandler handler)
    {
        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/"),
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    string? _apiKey;

    string ApiKey => _apiKey ??= PrivateStrings.TMDBApiV3Key;


    public async Task<T> Get<T>(string endpoint, Dictionary<string, string>? parameters = null) where T : class?
    {
        parameters ??= new Dictionary<string, string>();
        parameters.Add("api_key", ApiKey);
        var queryString = QueryHelpers.AddQueryString(endpoint, parameters);
        var response = await _httpClient.GetAsync(queryString);

        if (!response.IsSuccessStatusCode)
        {
            // TODO THIS!!!
            throw new NotImplementedException();
        }

        var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());

        if (result is null)
        {
            // TODO What should I actually do here?
            throw new Exception();
        }

        return result;
    }

    public Task<byte[]> GetBytes(string endpoint)
    {
        return _httpClient.GetByteArrayAsync(endpoint);
    }
}