using BackendTechHomework.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BackendTechHomework.Services
{
    class MusementService
    {
        static HttpClient client = new HttpClient();

        public MusementService()
        {
            client.BaseAddress = new Uri("https://api.musement.com/api/v3/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<City[]> GetCitiesAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<City[]>();
                return data;
            }
            return null;
        }
    }
}
