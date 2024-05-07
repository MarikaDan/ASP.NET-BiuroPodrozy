using BiuroPodrozy_Zad_dom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnumerable<TourDetailsViewModel> _tours = new List<TourDetailsViewModel> 
        {
            new TourDetailsViewModel
            {
                Id= 1,
                Country = "Chorwacja",
                City = "Rabac",
                PricePerPerson = "1200zł",
                NumberOfDays = 3,
                Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2020/6/4/d1/26168098.jpg",
                Description ="Wyjedź do ciepłego, słonecznego kraju i pozwiedzaj piękny Rabac!"
            },
            new TourDetailsViewModel
            {
                Id= 2,
                Country = "Chorwacja",
                City = "Orebic",
                PricePerPerson = "1900zł",
                NumberOfDays = 5,
                Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2021/9/22/d5/31052888.jpg",
                Description ="Wypocznij w przepięknej Chorwacji! W Orebicu czeka cię dużo atrakcji!"
            },
            new TourDetailsViewModel
            {
                Id= 3,
                Country = "Hiszpania",
                City = "Costa Del Sol",
                PricePerPerson = "1300zł",
                NumberOfDays = 3,
                Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2021/4/8/d48/28186183.jpg",
                Description ="Costa Del Sol - piękne miasto pełne atrakcji. Możesz tam być już teraz!"
            },
            new TourDetailsViewModel
            {
                Id= 4,
                Country = "Hiszpania",
                City = "Majorka",
                PricePerPerson = "1300zł",
                NumberOfDays = 4,
                Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2020/2/10/d42/24213358.jpg",
                Description ="Czy może być coś lepszego niż Majorka? Wyjedź w najbliższy weekend i ciesz się plażą!"
            },
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_tours);
        }
        public IActionResult Details(int id)
        {
            var tour = _tours.FirstOrDefault(x => x.Id == id);
            return View(tour);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}