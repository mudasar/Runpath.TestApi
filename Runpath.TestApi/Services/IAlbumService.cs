using Runpath.TestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public interface IAlbumService
    {
        Task<List<Album>> loadAllAlbumsAsync();
        Task<List<Album>> loadAllAlbumsFilteredAsync(int userId);
        Task<Album> loadSingleAlbumAsync(int albumId);
    }
}
