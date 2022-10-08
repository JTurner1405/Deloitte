using Deloitte.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Test
{
    public class ConfigurationTest
    {
        [Test]
        public void ConnectionStringTest()
        {
            var result = Configuration.GetConnectionString();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("Database=Deloitte"));
        }

        [Test]
        public void GetAPIKeyTest()
        {
            var result = Configuration.GetAPIKey();
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
        }

        [Test]
        public void GetRestCountryAddressTest()
        {
            var result = Configuration.GetRestCountryAddress();
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("countries"));
        }

        [Test]
        public void GetRestWeatherAddressTest()
        {
            var result = Configuration.GetRestWeatherAddress();
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("openweathermap"));
        }
    }
}
