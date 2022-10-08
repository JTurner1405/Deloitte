
using Deloitte.API.APICalls;
using Deloitte.DB;

namespace Deloitte.API.DI
{
    public static class ServiceDeclarations
    {
        public static IServiceCollection RegisterAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherAPI, WeatherAPI>();
            services.AddScoped<ICountryAPI, CountryAPI>();
            services.AddScoped<IDBConnection, DBConnection>();

            return services;
        }
    }
}