using Deloitte.Models.DB_Models;

namespace Deloitte.DB
{
    public interface IDBConnection
    {
        List<Cities> GetAllCities();
        Cities? GetCities(int id);
        Cities? GetCities(string name);
        bool RemoveCity(int id);
        bool UpdateCity(Cities city);
        Cities? CreateCity(Cities city);
    }
}