using KoiosTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace KoiosTask.Dal
{
    public class KoiosTaskDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public KoiosTaskDbContext(DbContextOptions<KoiosTaskDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(SeedCountries());
        }

        public List<Country> SeedCountries()
        {
            var countries = new List<Country>();
            int countryId = 1;

            string jsonString = File.ReadAllText(@"../KoiosTask.Dal/Seed/countries.json");
            countries = JsonConvert.DeserializeObject<List<Country>>(jsonString);

            countries.ForEach(x => { x.Id = countryId;countryId++; });

            return countries;
        }
    }
}
