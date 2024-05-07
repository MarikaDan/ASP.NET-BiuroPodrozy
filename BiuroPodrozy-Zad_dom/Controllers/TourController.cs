using Microsoft.AspNetCore.Mvc;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Service;
using BiuroPodrozy_Zad_dom.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozy_Zad_dom.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        
        public TourController(ITourService tourService)
        {
            _tourService =  tourService;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = _tourService.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddTour()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTour([Bind("ID,Country,City,PricePerPerson,NumberOfDays,Photo,Description")] TourViewModel tourViewModel)
        {
            if (!ModelState.IsValid) return View(tourViewModel);

            _tourService.Insert(tourViewModel);
            return RedirectToAction("Index", "Tour");

        }
        [HttpGet]
        public async Task<ActionResult> EditTour(int? tourId)
        {
            if (tourId == null) return NotFound();
            var model = _tourService.GetById(tourId.Value);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTour(int id, [Bind("ID,Country,City,PricePerPerson,NumberOfDays,Photo,Description")] TourViewModel tourViewModel)
        {
            if (id != tourViewModel.ID) return NotFound();
            if (!ModelState.IsValid) return View(tourViewModel);
            try
            {
                _tourService.Update(tourViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_tourService.Exists(tourViewModel.ID))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction("Index", "Tour");
        }
        [HttpGet]
        public async Task<ActionResult> DeleteTour(int? tourId)
        {
            if (tourId == null) return NotFound();

            var model = _tourService.GetById(tourId.Value);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int tourId)
        {
            _tourService.Delete(tourId);
            return RedirectToAction("Index", "Tour");
        }
    }
}
