using System;
using Xunit;
using BackendTechHomework.Services;
using BackendTechHomework.Models;
using System.Threading.Tasks;
using BackendTechHomework;
using System.Collections.Generic;

namespace BackendTechTest
{
    public class ServiceTest
    {
        [Fact]
        public async Task testGetCitiesAsync()
        {
            MusementService  musementService = new MusementService();
            // Get the cities
            City[] citiesList = await musementService.GetCitiesAsync("cities");
        }

        [Fact]
        public async Task testGetForecastWithApiKeyAsync()
        {
            WeatherService weatherService = new WeatherService();
            
            var weatherApiKey = "1b36f423ccd14cf7a2a131328211310";
            City cityTest = new City(); // Milano
            cityTest.Latitude = 45.4642;
            cityTest.Longitude = 9.1900;

            Weather forecast = await weatherService.GetForecastAsync(cityTest, weatherApiKey, 2);

        }

        [Fact]
        public async Task testGetForecastWithoutApiKeyAsync()
        {
            WeatherService weatherService = new WeatherService();

            var weatherApiKey = "";
            City cityTest = new City(); // Milano
            cityTest.Latitude = 45.4642;
            cityTest.Longitude = 9.1900;

            Weather forecast = await weatherService.GetForecastAsync(cityTest, weatherApiKey, 2);

        }

        [Fact]
        public async Task testShowCityWithoutForecast()
        {
            City cityTest = new City(); // Milano
            cityTest.Latitude = 45.4642;
            cityTest.Longitude = 9.1900;
            cityTest.Name = "Milano";

            Weather cityFor = new Weather();
            StartClass.ShowCity(cityTest, cityFor);

        }

        [Fact]
        public async Task testShowCityWithOneForecast()
        {
            City cityTest = new City(); // Milano
            cityTest.Latitude = 45.4642;
            cityTest.Longitude = 9.1900;
            cityTest.Name = "Milano";

            Weather cityFor = new Weather();
            cityFor.forecast = new Forecast();
            ForecastDay forecastDay = new ForecastDay();
            forecastDay.day = new Day();
            forecastDay.day.condition = new Condition();
            forecastDay.day.condition.code = 10;
            forecastDay.day.condition.text = "test-test";
            cityFor.forecast.forecastday = new List<ForecastDay>() {
             forecastDay
            };

            StartClass.ShowCity(cityTest, cityFor);

        }

        [Fact]
        public async Task testGlobal()
        {
            StartClass.RunAsync();
        }
    }
}
