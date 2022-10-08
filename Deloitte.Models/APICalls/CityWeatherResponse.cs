using Deloitte.Models.DB_Models;
using Deloitte.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Models.APICalls
{
    public class CityWeatherResponse
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int TouristRating { get; set; }
        public DateTime? DateEstablished { get; set; }
        public string EstimatedPopulation { get; set; }
        public string TwoDigitCountryCode {get;set;}
        public string ThreeDigitCountryCode { get; set;}
        public string CurrencyCode { get; set; }
        public List<string> Weather { get; set; }

        public CityWeatherResponse(Cities city)
        {
            this.CityId = city.Id;
            this.CityName = city.Name;
            this.State = city.State;
            this.Country = city.Country;
            this.TouristRating = city.TouristRating?? 0;
            this.DateEstablished = city.DateEstablished;
            this.EstimatedPopulation = city.EstimatePopulation;
            this.TwoDigitCountryCode = city.TwoDigitCountryCode;
            this.ThreeDigitCountryCode = city.ThreeDigitCountryCode;
            this.CurrencyCode = city.CurrencyCode;
        }

        public CityWeatherResponse(Cities city, Weather weather)
        {
            this.CityId = city.Id;
            this.CityName = city.Name;
            this.State = city.State;
            this.Country = city.Country;
            this.TouristRating = city.TouristRating ?? 0;
            this.DateEstablished = city.DateEstablished;
            this.EstimatedPopulation = city.EstimatePopulation;
            this.TwoDigitCountryCode = city.TwoDigitCountryCode;
            this.ThreeDigitCountryCode = city.ThreeDigitCountryCode;
            this.CurrencyCode = city.CurrencyCode;
            this.Weather = new List<string>();
            this.Weather.Add(weather.description);
        }

        public CityWeatherResponse(Cities city, List<RootWeather> hourlyWeather)
        {
            this.CityId = city.Id;
            this.CityName = city.Name;
            this.State = city.State;
            this.Country = city.Country;
            this.TouristRating = city.TouristRating ?? 0;
            this.DateEstablished = city.DateEstablished;
            this.EstimatedPopulation = city.EstimatePopulation;
            this.TwoDigitCountryCode = city.TwoDigitCountryCode;
            this.ThreeDigitCountryCode = city.ThreeDigitCountryCode;
            this.CurrencyCode = city.CurrencyCode;
            this.Weather = new List<string>();
            foreach (var hour in hourlyWeather)
            {
                var weather = hour.weather.FirstOrDefault();
                if (weather != null)
                {
                    var weatherDescription = weather.description;
                    this.Weather.Add(hour.dt_txt + " " + weatherDescription);
                }
            }
        }
    }
}
