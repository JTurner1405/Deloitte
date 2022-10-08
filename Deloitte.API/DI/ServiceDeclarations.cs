
using Deloitte.API.APICalls;

namespace Deloitte.API.DI
{
    public static class ServiceDeclarations
    {
        public static IServiceCollection RegisterAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherAPI, WeatherAPI>();
            services.AddScoped<ICountryAPI, CountryAPI>();

            return services;
        }
    }
}