using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Runpath.TestApi.Models;
using Runpath.TestApi.Services;

namespace Runpath.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {


        readonly IPhotoService photoService;
        readonly IAlbumService albumService;

        public PhotoController(IPhotoService photoService, IAlbumService albumService)
        {
            this.albumService = albumService;
            this.photoService = photoService;
        }


        [HttpGet]
        public async Task<List<Album>> Get(int userId = 0)
        {
            var albums = new List<Album>();
            if (userId != 0)
            {
                albums = await this.albumService.loadAllAlbumsFilteredAsync(userId);
            }
            else
            {
                albums = await this.albumService.loadAllAlbumsAsync();
            }

            foreach (var item in albums)
            {
                item.Photos = await this.photoService.loadAllPhotosForASingleAlbumAsync(item.Id);
            }
            return albums;
        }
    }
}
