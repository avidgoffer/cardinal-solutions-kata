using Kata04.Core.Services;
using Kata04.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Kata04.Test
{
    [TestClass]
    public class GivenAWeatherService
    {
        [TestMethod]
        public void ThenGetDayWithSmallesstTempSpreadReturnsTheDayWithSmallestTempSpread()
        {
            var weatherServie = new WeatherService(new List<WeatherDay>
                {
                    new WeatherDay
                    {
                        Day=1,
                        MaxTemp=50,
                        MinTemp=40
                    },
                    new WeatherDay
                    {
                        Day=2,
                        MaxTemp=50,
                        MinTemp=45
                    }
                });
            var weatherDay = weatherServie.GetDayWithSmallestTempSpread();

            const int expectedDay = 2;
            Assert.IsNotNull(weatherDay);
            Assert.AreEqual(expectedDay, weatherDay.Day);
        }
    }
}
