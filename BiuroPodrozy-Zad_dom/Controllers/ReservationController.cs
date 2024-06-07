using Microsoft.AspNetCore.Mvc;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Service;
using BiuroPodrozy_Zad_dom.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BiuroPodrozy_Zad_dom.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = _reservationService.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReservation([Bind("ReservationID,TotalPrice,From,To,TourID,ClientID")] ReservationViewModel reservationViewModel)
        {
            if (!ModelState.IsValid) return View(reservationViewModel);

            _reservationService.Insert(reservationViewModel);
            return RedirectToAction("Index", "Reservation");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> EditReservation(int? reservationId)
        {
            if (reservationId == null) return NotFound();
            var model = _reservationService.GetById(reservationId.Value);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> DeleteReservation(int? reservationId)
        {
            if (reservationId == null) return NotFound();

            var model = _reservationService.GetById(reservationId.Value);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int reservationId)
        {
            _reservationService.Delete(reservationId);
            return RedirectToAction("Index", "Reservation");
        }
    }
}
