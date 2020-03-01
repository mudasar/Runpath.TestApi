using Runpath.TestApi.Controllers;
using Runpath.TestApi.Models;
using Runpath.TestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Runpath.TestApi.Tests
{
    public class PhotoServiceUnitTests : IDisposable
    {

        private IDataSerializationService dataSerializationService;
        private RestClient restClient;
        private IPhotoService  photoService;

        public PhotoServiceUnitTests()
        {
           dataSerializationService = new JsonDataSerializationService();
            restClient = new RestClient(new System.Net.Http.HttpClient());
            photoService = new PhotoService(restClient, dataSerializationService);
        }

        public void Dispose()
        {
            restClient.Dispose();
        }
        

        [Fact]
        public async void Service_Returns_List_Of_Photos_Loaded()
        {
            var photos = await photoService.loadAllPhotosAsync();
            Assert.NotNull(photos);
            Assert.Equal(5000, photos.Count);
        }

        [Fact]
        public async void Service_Returns_List_Of_Photos_For_A_Single_Album_Loaded()
        {
            var photos = await photoService.loadAllPhotosForASingleAlbumAsync(1);
            Assert.NotNull(photos);
            Assert.Equal(50, photos.Count);
        }     
    }
}
