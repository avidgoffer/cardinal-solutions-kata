using System.Collections.Generic;
using Kata04.Data.Entities;
using System.IO;

namespace Kata04.Data.Readers
{
    public class WeatherFileReader : IWeatherReader
    {
        private readonly string _pathToData;

        // is this the best way to do this.  i wanted to enale a way to read the day agnostically
        public WeatherFileReader(string pathToData)
        {
            _pathToData = pathToData;
        }

        public IList<WeatherDay> GetAll()
        {
            // todo implement caching maybe?
            // todo recoginize when file changes?
            string[] data = File.ReadAllLines(_pathToData);
            var weatherData = new List<WeatherDay>();
            for (int i = 2; i < data.Length; ++i)  // skip first two lines
            {
                int day = -1;
                int.TryParse(data[i].Substring(2, 2), out day);
                int max = -1;
                int.TryParse(data[i].Substring(5, 3), out max);
                int min = -1;
                int.TryParse(data[i].Substring(11, 3), out min);
                weatherData.Add(new WeatherDay
                {
                    Day = day,
                    MaxTemp = max,
                    MinTemp = min
                });
            }
            return weatherData;
        }
    }
}