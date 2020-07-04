using QotD.Api.Models;
using QotD.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QotD.Client.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result> Get()
        {
            var response = await _httpClient.GetAsync("api/qotd");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var quote = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Result>(quote);
        }
    }
}
