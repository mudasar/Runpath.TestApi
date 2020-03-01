using Runpath.TestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public interface IPhotoService
    {
        Task<List<Photo>> loadAllPhotosAsync();
        Task<List<Photo>> loadAllPhotosForASingleAlbumAsync(int albumId);
    }
}
