using KoiosTask.Web.Models;
using KoiosTask.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
