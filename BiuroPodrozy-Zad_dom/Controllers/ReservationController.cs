using Microsoft.AspNetCore.Mvc;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Service;
using BiuroPodrozy_Zad_dom.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozy_Zad_dom.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = _reservationService.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddReservation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReservation([Bind("ReservationID,TotalPrice,From,To,TourID,ClientID")] ReservationViewModel reservationViewModel)
        {
            if (!ModelState.IsValid) return View(reservationViewModel);

            _reservationService.Insert(reservationViewModel);
            return RedirectToAction("Index", "Reservation");

        }
        [HttpGet]
        public async Task<ActionResult> EditReservation(int? reservationId)
        {
            if (reservationId == null) return NotFound();
            var model = _reservationService.GetById(reservationId.Value);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditReservation(int id, [Bind("ReservationID,TotalPrice,From,To,TourID,ClientID")] ReservationViewModel reservationViewModel)
        {
            if (id != reservationViewModel.ReservationID) return NotFound();
            if (!ModelState.IsValid) return View(reservationViewModel);
            try
            {
                _reservationService.Update(reservationViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_reservationService.Exists(reservationViewModel.ReservationID))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction("Index", "Reservation");
        }
        [HttpGet]
        public async Task<ActionResult> DeleteReservation(int? reservationId)
        {
            if (reservationId == null) return NotFound();

            var model = _reservationService.GetById(reservationId.Value);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int reservationId)
        {
            _reservationService.Delete(reservationId);
            return RedirectToAction("Index", "Reservation");
        }
    }
}
