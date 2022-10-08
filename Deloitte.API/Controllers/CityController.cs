using Deloitte.API.APICalls;
using Deloitte.API.Routes;
using Deloitte.DB;
using Deloitte.Models.APICalls;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte.API.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private IWeatherAPI weatherAPI;
        private ICountryAPI countryAPI;
        private IDBConnection connection;

        public CityController(IWeatherAPI weatherAPI, ICountryAPI countryAPI, IDBConnection connection)
        {
            this.weatherAPI = weatherAPI;
            this.countryAPI = countryAPI;
            this.connection = connection;
        }

        [HttpGet(APIRoute.GetCity)]
        public async Task<IActionResult> GetCity([FromRoute] string city)
        {
            return null;
        }

        [HttpDelete(APIRoute.CityById)]
        public async Task<IActionResult> DeleteCity([FromRoute] int cityId)
        {
            return null;
        }

        [HttpPost(APIRoute.City)]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityModel model)
        {
            return null;
        }

        [HttpPut(APIRoute.City)]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityModel model)
        {
            return null;
        }
    }
}
