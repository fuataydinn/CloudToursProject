using CloudTours.Management.Application.BusManuFactures;
using CloudTours.Management.Application.BusModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class BusModelController : Controller
    {
        private readonly IBusModelService _busService;
        private readonly IBusManuFactureService _busManuService;

        public BusModelController(IBusModelService busService, IBusManuFactureService busManuService)
        {
            _busService = busService;
            _busManuService = busManuService;
        }

        public IActionResult Index()
        {
            var busModelList = _busService.GetAllSummaries();
            @ViewBag.BusModelList = busModelList.Count();
            return View(busModelList);
        }
        public IActionResult Create()
        {
            var busManuList = _busManuService.GetAll();
            ViewBag.basManuList = new SelectList(busManuList, "BusManuFacturerId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO busModelDTO)
        {
            _busService.Create(busModelDTO);
            ViewBag.basManuList = _busManuService.GetAll();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var busModel = _busService.GetById(id);
            if (busModel != null)
            {
                return View(busModel);
            }
            else
            {
                return null;
            }
       
        }
        [HttpPost]
        public IActionResult Update(BusModelDTO busModelDTO)
        {
            _busService.Update(busModelDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var busModel = _busService.GetById(id);
            if (busModel != null)
            {
                return View(busModel);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult Delete(BusModelDTO busModelDTO)
        {
            _busService.Delete(busModelDTO);
            return RedirectToAction("Index");
        }
    }
}
