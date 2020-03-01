using Runpath.TestApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly string url = "https://jsonplaceholder.typicode.com/photos";
        private readonly IRestClient _client;
        private readonly IDataSerializationService dataSerializer;

        public PhotoService(IRestClient client, IDataSerializationService serializer)
        {
            this.dataSerializer = serializer;
            _client = client;
        }

        private async Task<string> loadPhotoJson(string url)
        {
            return await _client.GetDataAsync(url);
        }

        public async Task<List<Photo>> loadAllPhotosAsync()
        {
            return dataSerializer.DeserializeData<List<Photo>>(await this.loadPhotoJson(url));
        }


        public async Task<List<Photo>> loadAllPhotosForASingleAlbumAsync(int albumId)
        {
            var newUrl = $"{url}?albumId={albumId}";
            return dataSerializer.DeserializeData<List<Photo>>(await this.loadPhotoJson(newUrl));
        }
    }
}
