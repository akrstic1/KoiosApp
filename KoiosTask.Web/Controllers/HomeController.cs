using KoiosTask.Model;
using KoiosTask.Web.Models;
using KoiosTask.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KoiosTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;

        public HomeController(ILogger<HomeController> logger, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> Index()
        {
            var test = await _cityRepository.GetAllCities();
            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> GetCountryDropdown(int idSelected = 0)
        {
            List<SelectListItem> countryDropdown = new List<SelectListItem>();
            var allCountriesList = await _countryRepository.GetAllCountries();

            foreach(var country in allCountriesList)
            {
                countryDropdown.Add(new SelectListItem()
                {
                    Text = country.Name,
                    Value = country.Id.ToString()
                });
            }

            if(idSelected != 0)
            {
                countryDropdown.Find(x=>x.Value == idSelected.ToString()).Selected = true;
            }

            return PartialView("_CountryDropdown", countryDropdown);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City cityToAdd)
        {
            List<City> newCityList = new List<City>();

            await _cityRepository.Add(cityToAdd);

            newCityList = (await _cityRepository.GetAllCities()).ToList();
         
            return PartialView("_CityTable", newCityList);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCity(City city)
        {
            List<City> newCityList = new List<City>();
            var updatedCity = await _cityRepository.Update(city);
         
            newCityList = (await _cityRepository.GetAllCities()).ToList();

            return PartialView("_CityTable", newCityList);
        }

        [HttpPost]
        public async Task<IActionResult> GetUpdateCityForm(int cityId)
        {
            City cityToUpdate= await _cityRepository.GetCityById(cityId);

            return PartialView("_EditCity", cityToUpdate);
        }

        public async Task<IActionResult> DeleteCity(int id)
        {
            var cityToDelete = await _cityRepository.GetCityById(id);

            await _cityRepository.Delete(cityToDelete);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
