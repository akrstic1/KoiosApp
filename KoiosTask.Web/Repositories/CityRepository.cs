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
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _koiosTaskDbContext.Cities
                .Include(p => p.Country)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(City cityToAdd)
        {
            await _koiosTaskDbContext.Cities.AddAsync(cityToAdd);

            await _koiosTaskDbContext.SaveChangesAsync();
        }

        public async Task<City> Update(City city)
        {
            var entity = await GetCityById(city.Id);

            entity.Name = city.Name;
            entity.PostCode = city.PostCode;
            entity.CountryId = city.CountryId;

            await _koiosTaskDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(City cityToDelete)
        {
            _koiosTaskDbContext.Cities.Remove(cityToDelete);

            await _koiosTaskDbContext.SaveChangesAsync();
        }
    }
}
