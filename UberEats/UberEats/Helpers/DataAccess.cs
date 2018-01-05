using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UberEats.Helpers
{
    public class DataAccess
    {

        private readonly HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> ResponseAsync(string url, Object obj)
        {
            var uri = new Uri(string.Format(url, string.Empty));
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);

            return response;
        }
    }
}
