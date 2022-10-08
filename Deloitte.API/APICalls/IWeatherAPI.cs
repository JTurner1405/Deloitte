using Deloitte.Models.RestModels;

namespace Deloitte.API.APICalls
{
    public interface IWeatherAPI
    {
        Task<RootWeather?> GetWeatherByLatLang(double latitude, double longitude);
        Task<RootWeather?> GetWeatherByCityTest(string city);
        Task<RootWeather?> GetWeatherByCityTest(string city, string subRegion);
    }
}