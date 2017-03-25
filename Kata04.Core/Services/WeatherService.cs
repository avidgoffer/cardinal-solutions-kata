using Kata04.Data;
using Kata04.Data.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04.Core.Services
{
    public class WeatherService
    {
        private IList<WeatherDay> _weatherData;

        public WeatherService(IList<WeatherDay> weatherData)
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
