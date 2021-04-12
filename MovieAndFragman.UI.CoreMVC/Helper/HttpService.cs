using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Helper
{
    public class HttpService<Entity>
    {
        private const string APIKEYNAME = "ApiKey";
        private const string APIUrlNAME = "ApiUrl";
        static string url = string.Empty;
        static HttpClient client = new HttpClient();
        private static IConfiguration _configuration;
        static void GetApi()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
            string apiKey = _configuration.GetValue<string>(APIKEYNAME);
            url = _configuration.GetValue<string>(APIUrlNAME);
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
        }

        public static async Task<string> Get(string method)
        {
            GetApi();
            string serviceUrl = $"{url}{method}";
            using (var r = await client.GetAsync(new Uri(serviceUrl)))
                return await r.Content.ReadAsStringAsync();
        }
        public static async Task<string> Post(string method, Entity entity)
        {
            GetApi();
            string serviceUrl = $"{url}{method}";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(serviceUrl, httpContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static async Task<string> Put(string method, Entity entity)
        {
            GetApi();
            string serviceUrl = $"{url}{method}";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync(serviceUrl, httpContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static async Task<string> Delete(string method)
        {
            GetApi();
            string serviceUrl = $"{url}{method}";
            using (HttpResponseMessage response = await client.DeleteAsync(serviceUrl))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
