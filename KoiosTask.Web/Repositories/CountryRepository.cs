using KoiosTask.Dal;
using KoiosTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiosTask.Web.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly KoiosTaskDbContext _koiosTaskDbContext;

        public CountryRepository(KoiosTaskDbContext koiosTaskDbContext)
        {
            _koiosTaskDbContext = koiosTaskDbContext;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _koiosTaskDbContext.Countries.ToListAsync();
        }
    }
}