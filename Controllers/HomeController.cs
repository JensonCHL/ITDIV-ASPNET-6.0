using ITDIV.Models;
using ITDIV.Views.Home;
using ITDIV.Views.Account;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ITDIV.Data;
using Microsoft.EntityFrameworkCore;
using ITDIV.Models.SewaView;
using ITDIV.Models.AvailableView;

namespace ITDIV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;

        // }
        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext appdbcontext)
        {
            this.appDbContext = appdbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View(new List<AvailableModel>());
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime? pickupDate, DateTime? returnDate, int? year)
        {


            var availableCars = (from car in appDbContext.MsCar
                                       join image in appDbContext.MsCarImages on car.Car_id equals image.Car_id into images
                                       from img in images.DefaultIfEmpty() 
                                       where
                                           (!year.HasValue || car.year == year) &&
                                           !appDbContext.TrRental.Any(rental =>
                                               rental.car_id == car.Car_id &&
                                               rental.rental_date < returnDate &&
                                               rental.return_date > pickupDate) 
                                       select new AvailableModel 
                                       {
                                           Car_id = car.Car_id,
                                           Name = car.name,
                                           Year = car.year,
                                           PricePerDay = car.price_per_day,
                                           ImageLink = img.image_link 
                                       })
                            .ToList();


            return View("Index", availableCars);
        }



        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View("Contact");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
