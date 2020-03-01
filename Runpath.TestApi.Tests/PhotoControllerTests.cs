using Runpath.TestApi.Controllers;
using Runpath.TestApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Runpath.TestApi.Tests
{
  public  class PhotoControllerTests        :IDisposable
    {

        private IDataSerializationService dataSerializationService;
        private RestClient restClient;
        private IPhotoService  photoService;
        private PhotoController controller;
        private IAlbumService albumService;

        public PhotoControllerTests()
        {
            restClient = new RestClient(new System.Net.Http.HttpClient());
            dataSerializationService = new JsonDataSerializationService();
            albumService = new AlbumService(restClient, dataSerializationService);
        photoService = new PhotoService(restClient, dataSerializationService);
          controller = new PhotoController(photoService, albumService);
        }

           public void Dispose()
        {
            restClient.Dispose();
        }

        [Fact]
        public async void Service_Returns_All_Albums_With_All_Photos()
        {
           
            var albums = await controller.Get();
            Assert.NotNull(albums);
            Assert.Equal(100, albums.Count);
            Assert.Equal(50, albums[0].Photos.Count);
        }

        [Fact]
        public async void Service_Returns_All_Albums_With_All_Photos_Filtered_By_UserId()
        {
            var albums = await controller.Get(1);
            Assert.NotNull(albums);
            Assert.Equal(10, albums.Count);
            Assert.Equal(50, albums[0].Photos.Count);
        }

    }
}
