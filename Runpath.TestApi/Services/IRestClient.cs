using System;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public interface IRestClient
    {
        Task<string> GetDataAsync(string url);
    }
}
