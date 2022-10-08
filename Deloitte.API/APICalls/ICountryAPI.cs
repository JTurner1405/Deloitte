using Deloitte.Models.RestModels;

namespace Deloitte.API.APICalls
{
    public interface ICountryAPI
    {
        Task<List<Country>?> GetAllCountries();
        Task<Country?> GetCountry(string value);
        Task<List<Country>?> GetCountriesBySubRegion(string value);
        Task<List<Country>?> GetCountriesByRegion(string value);
        Task<List<Country>?> GetCountriesByCapital(string value);
    }
}