using KoiosTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiosTask.Web.Repositories
{
    public interface ICityRepository
    {
        Task Add(City cityToAdd);
        Task Delete(City cityToDelete);
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int id);
    }
}