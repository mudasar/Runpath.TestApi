using Runpath.TestApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Runpath.TestApi.Tests
{
    public class AlbumServiceTests : IDisposable
    {
        private IDataSerializationService dataSerializationService;
        private RestClient restClient;
        private IAlbumService albumService;

        public AlbumServiceTests()
        {
            dataSerializationService = new JsonDataSerializationService();
            restClient = new RestClient(new System.Net.Http.HttpClient());
            albumService = new AlbumService(restClient, dataSerializationService);
        }

        public void Dispose()
        {
            restClient.Dispose();
        }


        [Fact]
        public async void Can_Load_All_Albums()
        {
            var albums = await albumService.loadAllAlbumsAsync();
            Assert.NotNull(albums);
            Console.WriteLine(albums);
            Assert.NotEmpty(albums);

        }

        [Fact]
        public async void Service_Returns_A_Single_Album()
        {
            var album = await albumService.loadSingleAlbumAsync(1);
            Assert.NotNull(album);
        }

        [Fact]
        public async void Service_Returns_List_Of_Albums_Filtered_By_UserId()
        {
            var albums = await albumService.loadAllAlbumsFilteredAsync(1);
            Assert.NotNull(albums);
            Assert.NotEmpty(albums);
            Assert.Equal(10, albums.Count);
        }


    }
}
