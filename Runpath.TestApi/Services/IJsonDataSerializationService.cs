using System;
using System.Linq;

namespace Runpath.TestApi.Services
{
    public interface IDataSerializationService
    {
        T DeserializeData<T>(string jsonData);
        string SerializeData<T>(T data);
    }
}
