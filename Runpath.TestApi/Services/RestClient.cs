using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public class RestClient : IDisposable, IRestClient
    {
        private readonly HttpClient _client;
        public RestClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<string> GetDataAsync(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Error {response.StatusCode} - {response.ReasonPhrase}");
            }
        }


    }
}
