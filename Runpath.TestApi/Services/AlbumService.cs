using Runpath.TestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly string url = "https://jsonplaceholder.typicode.com/albums";

        private readonly IRestClient _client;
        private readonly IDataSerializationService dataSerializer;

        public AlbumService(IRestClient client, IDataSerializationService serializer)
        {
            this.dataSerializer = serializer;
            _client = client;
        }

        private async Task<string> loadAlbumJson(string url)
        {
            return await _client.GetDataAsync(url);
        }

        public async Task<List<Album>> loadAllAlbumsAsync()
        {
            return dataSerializer.DeserializeData<List<Album>>(await this.loadAlbumJson(url));
        }

        public async Task<List<Album>> loadAllAlbumsFilteredAsync(int userId)
        {

            var newUrl = $"{url}?userId={userId}";
            return dataSerializer.DeserializeData<List<Album>>(await this.loadAlbumJson(newUrl));
        }

        public async Task<Album> loadSingleAlbumAsync(int albumId)
        {
            var newUrl = $"{url}/{albumId}";
            return dataSerializer.DeserializeData<Album>(await this.loadAlbumJson(newUrl));
        }
    }
}
