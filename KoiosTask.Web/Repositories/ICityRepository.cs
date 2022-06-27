using KoiosTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiosTask.Web.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}