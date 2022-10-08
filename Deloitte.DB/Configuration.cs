using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.DB
{
    public static class Configuration
    {
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            return config;
        }

        public static string GetConnectionString()
        {
            return GetConfiguration().GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        public static string GetAPIKey()
        {
            return GetConfiguration().GetValue<string>("AppSettings:APIKey");
        }

        public static string GetRestCountryAddress()
        {
            return GetConfiguration().GetValue<string>("AppSettings:RestCountry");
        }

        public static string GetRestWeatherAddress()
        {
            return GetConfiguration().GetValue<string>("AppSettings:RestWeather");
        }
    }
}
