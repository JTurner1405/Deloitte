using Deloitte.API.APICalls;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Test
{
    public class CountryAPITests
    {
        private CountryAPI api;

        [SetUp]
        public void Setup()
        {
            api = new CountryAPI();
        }

        [Test]
        public void GetAllCountriesTest()
        {
            var result = api.GetAllCountries().Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetCountriesTest()
        {
            var result = api.GetCountry("gb").Result;

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetCountriesSubRegionTest()
        {
            var result = api.GetCountriesBySubRegion("europe").Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetCountriesRegionTest()
        {
            var result = api.GetCountriesByRegion("europe").Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetCountriesCapitalTest()
        {
            var result = api.GetCountriesByCapital("london").Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

    }
}
