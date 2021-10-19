using BackendTechHomework.Services;
using BackendTechHomework.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace BackendTechHomework
{
    class Program
    {

        static void ShowCity(City city, Weather weather)
        {
            var logMessage = $"Processed city {city.Name} | ";
            foreach (ForecastDay forecastDay in weather.forecast.forecastday)
            {
                logMessage = logMessage + forecastDay.day.condition.text + " - ";
            }
            // for each day is added to logMessage a string to separate different days, but it should be removed at the end of message
            logMessage = logMessage.Substring(0, logMessage.Length - 3);
            Console.WriteLine(logMessage);
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<Program>()
                .Build();

                var weatherApiKey = config.GetSection("WeatherApiKey");

                MusementService musementService = new MusementService();
                // Get the cities
                City[] citiesList = await musementService.GetCitiesAsync("cities");
                if (citiesList.Length > 0)
                {
                    // sort the cities list by name
                    var list = from city in citiesList
                               orderby city.Name
                               select city;

                    WeatherService weatherService = new WeatherService();

                    Array.ForEach<City>(list.ToArray<City>(), async city =>
                    {
                        //Get 2 days forecast for each city
                        Weather forecast = await weatherService.GetForecastAsync(city, weatherApiKey.Value, 2);
                        ShowCity(city, forecast);
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
