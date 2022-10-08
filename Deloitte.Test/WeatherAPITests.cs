using Deloitte.API.APICalls;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Test
{
    public class WeatherAPITests
    {
        private WeatherAPI api;

        [SetUp]
        public void Setup()
        {
            api = new WeatherAPI();
        }

        [Test]
        public void GetWeatherByLatLangTest()
        {
            var result = api.GetWeatherByLatLang(54.0, -2.0).Result;

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWeatherByCityTest()
        {
            var result = api.GetWeatherByCityTest("london").Result;

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWeatherByCityAndSubRegionTest()
        {
            var result = api.GetWeatherByCityTest("london", "unitedkingdom").Result;

            Assert.IsNotNull(result);
        }
    }
}
