using Deloitte.Models.DB_Models;

namespace Deloitte.DB
{
    public interface IDBConnection
    {
        List<Cities> GetAllCities();
        Cities? GetCities(int id);
        List<Cities>? GetCities(string name);
        List<Cities>? GetCities(string name, string state);
        bool RemoveCity(int id);
        bool UpdateCity(Cities city);
        Cities? CreateCity(Cities city);
    }
}