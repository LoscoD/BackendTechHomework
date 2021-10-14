using BackendTechHomework.Services;
using BackendTechHomework.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace BackendTechHomework
{
    class Program
    {

        static void ShowCity(City city)
        {
            var logMessage = $"Processed city {city.Name} | ";
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
                MusementService musementService = new MusementService();
                // Get the cities
                City[] citiesList = await musementService.GetCitiesAsync("cities");
                if (citiesList.Length > 0)
                {

                    var list = from city in citiesList
                               orderby city.Name
                               select city;

                    Array.ForEach<City>(list.ToArray<City>(), city =>
                    {
                        ShowCity(city);
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
