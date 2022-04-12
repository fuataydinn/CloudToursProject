using CloudTours.Management.Application.Cities;
using CloudTours.Management.Application.Stations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly ICityService _cityService;

        public StationController(IStationService stationService, ICityService cityService)
        {
            _stationService = stationService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var stations = _stationService.GetSummaries();
            ViewBag.StationsList = stations.Count();
            return View(stations);
        }
        public IActionResult Create()
        {
            var cityList = _cityService.GetAll();
            ViewBag.Cities = new SelectList(cityList, "CityId", "CityName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(StationDTO stationDTO)
        {
            _stationService.Create(stationDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var city = _stationService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(StationDTO stationDTO)
        {
            _stationService.Delete(stationDTO);
            return RedirectToAction("Index", "Station");
        }

        public IActionResult Update(int id)
        {
            var station = _stationService.GetById(id);
            var cityList = _cityService.GetAll();
            ViewBag.City = new SelectList(cityList, "CityId", "CityName", station.CityId);
            return View(station);
        }
        [HttpPost]
        public IActionResult Update(StationDTO stationDTO)
        {
            _stationService.Update(stationDTO);
            return RedirectToAction("Index", "Station");
        }

    }
}
