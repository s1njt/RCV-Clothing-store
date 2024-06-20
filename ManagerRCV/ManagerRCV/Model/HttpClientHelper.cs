using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerRCV.Model
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await httpClient.PostAsync(url, content);
        }
    }
}
