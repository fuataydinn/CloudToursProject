using CloudTours.Management.Application.BusManuFactures;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CloudTours.Management.Presentation.Controllers
{
    public class BusManuFacturerController : Controller
    {
        private readonly IBusManuFactureService _busService;

        public BusManuFacturerController(IBusManuFactureService service)
        {
            _busService = service;
        }

        public IActionResult Index()
        {
            var busManuFacturerList=_busService.GetAll();
            ViewBag.BusManuFacturers = busManuFacturerList.Count();
            return View(busManuFacturerList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusManuFacturerDTO busManuFacturerDTO)
        {
            _busService.Create(busManuFacturerDTO);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           var busManuFacturer=_busService.GetById(id);
            return View(busManuFacturer);
        }
        [HttpPost]
        public IActionResult Delete(BusManuFacturerDTO busManuFacturerDTO)
        {
            _busService.Delete(busManuFacturerDTO);
            return RedirectToAction("Index", "BusManuFacturer");
        }

        public IActionResult Update(int id)
        {
            var bus=_busService.GetById(id);
            return View(bus);
        }
        [HttpPost]
        public IActionResult Update(BusManuFacturerDTO busManuFacturerDTO)
        {
            _busService.Update(busManuFacturerDTO);
            return RedirectToAction("Index", "BusManuFacturer");
        }
    }
}
