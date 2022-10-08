namespace Deloitte.API.Routes
{
    public static class APIRoute
    {
        private const string cityName = "{city}";
        private const string cityId = "{cityId}";

        public const string City = "/City";
        public const string GetCity = City + "/" + cityName;
        public const string GetCityHourly = City + "/HourlyWeather/" + cityName;
        public const string CityById = City + "/" + cityId;

        public const string Setup = "/Setup";
    }
}
