using Newtonsoft.Json;
using Runpath.TestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.TestApi.Services
{
    public class JsonDataSerializationService : IDataSerializationService
    {

        public string SerializeData<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T DeserializeData<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }


    }
}
