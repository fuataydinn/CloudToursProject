using CloudTours.Management.Application.Cities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var cities = _cityService.GetAll();
            ViewBag.cityList = cities.Count();
            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CityDTO cityDTO)
        {
            _cityService.Create(cityDTO);
            return RedirectToAction("Index","City");
        }

        public IActionResult Delete(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(CityDTO cityDTO)
        {
            _cityService.Delete(cityDTO);
            return RedirectToAction("Index", "City");
        }

        public IActionResult Update(int id)
        {
            var city=_cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public  IActionResult Update(CityDTO cityDTO)
        {
            _cityService.Update(cityDTO);
            return RedirectToAction("Index", "City");
        }
    }
}
