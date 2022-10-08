using Deloitte.Models.RestModels;

namespace Deloitte.API.APICalls
{
    public interface IWeatherAPI
    {
        Task<List<RootWeather>?> GetWeatherByLatLang(double latitude, double longitude);
        Task<List<RootWeather>?> GetWeatherByCityTest(string city);
        Task<List<RootWeather>?> GetWeatherByCityTest(string city, string subRegion);
    }
}