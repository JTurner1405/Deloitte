using Deloitte.DB;
using Deloitte.Models.RestModels;
using Newtonsoft.Json;
using RestSharp;

namespace Deloitte.API.APICalls
{
    public class CountryAPI : ICountryAPI
    {
        private RestClient client;

        public CountryAPI()
        {
            client = new RestClient(Configuration.GetRestCountryAddress());
        }

        public async Task<List<Country>?> GetAllCountries()
        {
            var request = new RestRequest("all", Method.Get);

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Country>>(response.Content);
                return result;
            }

            return null;
        }

        public async Task<Country?> GetCountry(string value)
        {
            var request = new RestRequest("name/" + value, Method.Get);

            var response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Country>>(response.Content);
                return result.FirstOrDefault();
            }

            return null;
        }

        public async Task<List<Country>?> GetCountriesBySubRegion(string value)
        {
            var request = new RestRequest("subregion/" + value, Method.Get);

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Country>>(response.Content);
                return result;
            }

            return null;
        }

        public async Task<List<Country>?> GetCountriesByRegion(string value)
        {
            var request = new RestRequest("region/" + value, Method.Get);

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Country>>(response.Content);
                return result;
            }

            return null;
        }

        public async Task<List<Country>?> GetCountriesByCapital(string value)
        {
            var request = new RestRequest("capital/" + value, Method.Get);

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Country>>(response.Content);
                return result;
            }

            return null;
        }
    }
}
