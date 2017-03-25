using Kata04.Core.Services;
using Kata04.Data.Readers;
using System;
using System.IO;
using System.Linq;

namespace Kata04
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToData;
            if (!args.Any())
            {
                Console.WriteLine("No arguents passed assuming weather.dat file is in same directory as execcutable.");
                pathToData = "./weather.dat";
            }
            else
            {
                pathToData = args[0];
            }

            if(!File.Exists(pathToData))
            {
                Console.WriteLine($"Could not find data: {pathToData}");
                return;
            }

            var weatherData = new WeatherFileReader(pathToData).GetAll();
            var dayWithSmallestTempSread = new WeatherService(weatherData).GetDayWithSmallestTempSpread();
            Console.WriteLine($"The day with the samllest temperature spread is: {dayWithSmallestTempSread.Day}");

            Console.ReadKey();
        }
    }
}