using BiuroPodrozy_Zad_dom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.Service;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Controllers;

//[Authorize(Roles = "Admin")]
public class AdminController : Controller
{

	private readonly IClientService _clientService;
	private readonly ITourService _tourService;

	public AdminController(IClientService clientService, ITourService tourService)
	{
		_clientService = clientService;
		_tourService = tourService;
	}

	// GET
	public IActionResult Index()
	{

		var adminVm = new AdminPanelViewModel
		{
			ClientsCount = 249,
			ToursCount = 14,
			ReservationsCount = 153,

            Tours =
            [
                new()
                {
                    Country="Chorwacja",City = "Rabac",PricePerPerson = "1200zł",NumberOfDays = 3
                },
                new()
                {
                    Country = "Chorwacja",City = "Orebic",PricePerPerson = "1900zł",NumberOfDays = 5
                },
                new()
                {
                   Country = "Hiszpania",City = "Costa Del Sol",PricePerPerson = "1300zł",NumberOfDays = 3
                },
                new()
                {
                    Country = "Hiszpania",City = "Majorka",PricePerPerson = "1300zł",NumberOfDays = 4
                },

             ]
        };

		return View(adminVm);
	}
}