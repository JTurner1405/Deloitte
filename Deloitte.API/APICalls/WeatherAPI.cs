using Deloitte.DB;
using Deloitte.Models.RestModels;
using Newtonsoft.Json;
using RestSharp;

namespace Deloitte.API.APICalls
{
    public class WeatherAPI : IWeatherAPI
    {
        private RestClient client;
        private string apiKey;
        public WeatherAPI()
        {
            client = new RestClient(Configuration.GetRestWeatherAddress());
            apiKey = Configuration.GetAPIKey();
        }

        public async Task<List<RootWeather>?> GetWeatherByLatLang(double latitude, double longitude)
        {
            var request = new RestRequest(String.Format("forecast?lat={0}&lon={1}&appid={2}", latitude, longitude, apiKey), Method.Get);

            var response = await client.GetAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Root>(response.Content);
                return result.list;
            }
            return null;
        }

        public async Task<List<RootWeather>?> GetWeatherByCityTest(string city)
        {
                var request = new RestRequest(String.Format("forecast?q={0}&appid={1}", city, apiKey), Method.Get);

                var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Root>(response.Content);
                    return result.list;
                }
            return null;
        }

        public async Task<List<RootWeather>?> GetWeatherByCityTest(string city, string subRegion)
        {
            var request = new RestRequest(String.Format("forecast?q={0},{1}&appid={2}", city, subRegion, apiKey), Method.Get);

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Root>(response.Content);
                return result.list;
            }
            return null;
        }
    }
}
