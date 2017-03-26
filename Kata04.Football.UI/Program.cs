using Kata04.Data.Readers;
using Kata04.Football.Core.Services;
using System;
using System.IO;
using System.Linq;

namespace Kata04.Football.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToData;
            if (!args.Any())
            {
                Console.WriteLine("No arguents passed assuming football.dat file is in same directory as execcutable.");
                pathToData = "./football.dat";
            }
            else
            {
                pathToData = args[0];
            }

            if (!File.Exists(pathToData))
            {
                Console.WriteLine($"Could not find data: {pathToData}");
                return;
            }

            var weatherData = new FootballFileReader(pathToData).GetAll();
            var teamWithSmallestScoreDifference = new FootballService(weatherData).GetTeamWithSmallestScoringDifference();
            Console.WriteLine($"The team with the samllest score difference is: {teamWithSmallestScoreDifference.TeamName}");

            Console.ReadKey();
        }
    }
}
