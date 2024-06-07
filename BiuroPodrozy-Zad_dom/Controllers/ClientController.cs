using Microsoft.AspNetCore.Mvc;
using BiuroPodrozy_Zad_dom.Service;
using BiuroPodrozy_Zad_dom.ViewModels;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace BiuroPodrozy_Zad_dom.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IValidator<ClientViewModel> _validator;

        public ClientController(IClientService clientService, IValidator<ClientViewModel> validator)
        {
            _clientService = clientService;
            _validator = validator;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = _clientService.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
                return NotFound();

            var result = _clientService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,FirstName,LastName,Email,PhoneNumber")] ClientViewModel clientViewModel)
        {
            var result = await _validator.ValidateAsync(clientViewModel);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);
                
                return View(clientViewModel);
            }

            _clientService.Insert(clientViewModel);
            return RedirectToAction("Index", "Client");

        }
        [HttpGet]
        public async Task<ActionResult> Edit(string? id)
        {
            if (id == null) return NotFound();

            var model = _clientService.GetById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("ID,FirstName,LastName,Email,PhoneNumber")] ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id) return NotFound();

            var result = await _validator.ValidateAsync(clientViewModel);

            if (!ModelState.IsValid || !result.IsValid)
            {
                result.AddToModelState(ModelState);

                return View(clientViewModel);
            }

            try
            {
                _clientService.Update(clientViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_clientService.Exists(clientViewModel.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction("Index", "Client");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(string? id)
        {
            if (id == null) return NotFound();

            var model = _clientService.GetById(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            _clientService.Delete(id);
            return RedirectToAction("Index", "Client");
        }
    }
}
