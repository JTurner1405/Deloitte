using Deloitte.API.APICalls;
using Deloitte.API.Routes;
using Deloitte.DB;
using Deloitte.Models.APICalls;
using Deloitte.Models.DB_Models;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CityWeatherResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCity([FromRoute] string city)
        {
            var dbSearchResult = connection.GetCities(city);
            if(dbSearchResult != null && dbSearchResult.Any())
            {
                var list = new List<CityWeatherResponse>();
                foreach(var result in dbSearchResult)
                {
                    var rootWeather = await weatherAPI.GetWeatherByCityTest(result.Name, result.Country.Replace(" ", string.Empty));

                    var weather = rootWeather.FirstOrDefault().weather.FirstOrDefault();
                    if(weather != null)
                    {
                        list.Add(new CityWeatherResponse(result, weather));
                    }
                    else
                    {
                        list.Add(new CityWeatherResponse(result));
                    }
                }

                return Ok(list);
            }

            return NotFound("City not found");
        }

        [HttpGet(APIRoute.GetCityHourly)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CityWeatherResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCityHourlyWeather([FromRoute] string city)
        {
            var dbSearchResult = connection.GetCities(city);
            if (dbSearchResult != null && dbSearchResult.Any())
            {
                var list = new List<CityWeatherResponse>();
                foreach (var result in dbSearchResult)
                {
                    var rootWeather = await weatherAPI.GetWeatherByCityTest(result.Name, result.Country.Replace(" ", string.Empty));

                    if (rootWeather != null)
                    {
                        list.Add(new CityWeatherResponse(result, rootWeather));
                    }
                    else
                    {
                        list.Add(new CityWeatherResponse(result));
                    }
                }

                return Ok(list);
            }

            return NotFound("City not found");
        }

        [HttpDelete(APIRoute.CityById)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteCity([FromRoute] int cityId)
        {
            try
            {
                var result = connection.RemoveCity(cityId);
                if (result)
                {
                    return Ok("Deleted successfully");
                }
                else
                {
                    return NotFound("No City found with id " + cityId);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(APIRoute.City)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cities))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityModel model)
        {
            try
            {
                var result = connection.CreateCity(model.ConvertToCity());
                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest("An Error has occurred");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(APIRoute.City)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityModel model)
        {
            try
            {
                var city = connection.GetCities(model.Id);
                if(city == null)
                {
                    return NotFound("No city found to update");
                }

                var result = connection.UpdateCity(model.ConvertToCity(city));

                if (result)
                {
                    return Ok("Updated successfully");
                }
                return BadRequest("An error has occurred updating the city");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(APIRoute.Setup)]
        public async Task<IActionResult> PopulateDatabase()
        {
            try
            {
                var countries = await countryAPI.GetAllCountries();

                var dbCities = connection.GetAllCities();

                foreach (var country in countries)
                {
                    if (country != null && country.capital != null && country.subregion != null)
                    {
                        var cap = country.capital.FirstOrDefault();
                        var state = country.subregion.ToLower();
                        var commonName = country.name.common.ToLower();

                        if (cap != null)
                        {
                            if (!dbCities.Any(x => x.Name.ToLower().Equals(cap.ToLower())
                                    && x.State.ToLower().Equals(state)
                                    && x.Country.ToLower().Equals(commonName)))
                            {
                                connection.CreateCity(new Cities(country));
                            }
                        }
                    }
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
