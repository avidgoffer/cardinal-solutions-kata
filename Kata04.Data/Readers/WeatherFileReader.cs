using System.Collections.Generic;
using Kata04.Data.Entities;
using Kata04.Generic.Data.Readers;

namespace Kata04.Data.Readers
{
    public class WeatherFileReader
    {
        private readonly string _pathToData;

        // is this the best way to do this.  i wanted to enale a way to read the data agnostically
        public WeatherFileReader(string pathToData)
        {
            _pathToData = pathToData;
        }

        public IEnumerable<WeatherDay> GetAll()
        {
            return new FileReader<WeatherDay>().GetAll(_pathToData, x =>
            {
                if (x.Length < 13) return null;
                int day = -1;
                if (!int.TryParse(x.Substring(2, 2), out day)) return null;
                int max = -1;
                if (!int.TryParse(x.Substring(5, 3), out max)) return null;
                int min = -1;
                if (!int.TryParse(x.Substring(11, 3), out min)) return null;
                return new WeatherDay
                {
                    Day = day,
                    MaxTemp = max,
                    MinTemp = min
                };
            });
        }
    }
}