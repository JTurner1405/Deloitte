using Deloitte.API.APICalls;
using Deloitte.API.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte.API.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private IWeatherAPI weatherAPI;
        private ICountryAPI countryAPI;

        public CityController(IWeatherAPI weatherAPI, ICountryAPI countryAPI)
        {
            this.weatherAPI = weatherAPI;
            this.countryAPI = countryAPI;
        }

        [HttpGet(APIRoute.GetCity)]
        public async Task<IActionResult> GetCity([FromRoute] city)
        {

        }
    }
}
