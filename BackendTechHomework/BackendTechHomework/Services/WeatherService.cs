using BackendTechHomework.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BackendTechHomework.Services
{
    class WeatherService
    {
        static HttpClient client = new HttpClient();

        public WeatherService()
        {
            client.BaseAddress = new Uri("http://api.weatherapi.com/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Weather> GetForecastAsync(City city, int numDays)
        {
            HttpResponseMessage response = await client.GetAsync("forecast.json?key=1b36f423ccd14cf7a2a131328211310&q=" + city.Latitude + "," + city.Longitude + "&days=" + numDays);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Weather>();
                return data;
            }
            return null;
        }
    }
}
