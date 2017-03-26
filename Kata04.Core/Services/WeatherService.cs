using Kata04.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Kata04.Core.Services
{
    public class WeatherService
    {
        private IEnumerable<WeatherDay> _weatherData;

        public WeatherService(IEnumerable<WeatherDay> weatherData)
        {
            _weatherData = weatherData;
        }

        public WeatherDay GetDayWithSmallestTempSpread()
        {
            return _weatherData
                .FirstOrDefault(x => x.MaxTemp - x.MinTemp == _weatherData.Min(y => y.MaxTemp - y.MinTemp));
        }
    }
}
