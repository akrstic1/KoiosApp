using KoiosTask.Dal;
using KoiosTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiosTask.Web.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly KoiosTaskDbContext _koiosTaskDbContext;

        public CityRepository(KoiosTaskDbContext koiosTaskDbContext)
        {
            _koiosTaskDbContext = koiosTaskDbContext;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _koiosTaskDbContext.Cities
                .Include(x=>x.Country)
                .ToListAsync();
        }
    }
}
