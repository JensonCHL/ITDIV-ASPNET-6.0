using ITDIV.Models;
using ITDIV.Views.Home;
using ITDIV.Views.Account;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ITDIV.Data;
using Microsoft.EntityFrameworkCore;
using ITDIV.Models.SewaView;
using AspNetCoreGeneratedDocument;


namespace ITDIV.Controllers
{
    public class SewaController : Controller
    {

        private readonly AppDbContext appDbContext;

        public SewaController(AppDbContext appdbcontext)
        {
            this.appDbContext = appdbcontext;
        }


        [HttpGet]
        public async Task<IActionResult> Sewa(string CarId)
        {
            var customerId = HttpContext.Session.GetString("Customer_id");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("Login", "Account");
            }

            var imageLinks = await appDbContext.MsCarImages
            .Where(img => img.Car_id == CarId)
            .Select(img => img.image_link)
            .ToListAsync();

            var carDetails = await appDbContext.MsCar
        .Where(c => c.Car_id == CarId)
        .Select(c => new SewaView
        {
            Car_id = c.Car_id,
            name = c.name,
            year = c.year,
            model = c.model,
            transmission = c.transmission,
            price_per_day = c.price_per_day,
            number_of_car_seats = c.number_of_car_seats,
            image_link = string.Join(", ", imageLinks)
        })
        .FirstOrDefaultAsync();
            if (carDetails == null)
            {
                return NotFound(); 
            }
            return View(new List<SewaView> { carDetails });
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmRental(string carId)
        {
            if (string.IsNullOrEmpty(carId))
            {
                return BadRequest("Car ID cannot be null or empty.");
            }

            var car = await appDbContext.MsCar.FindAsync(carId);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            car.Status = true; 

            // Save changes to the database
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home"); 
        }

        public IActionResult Index()
        {
            return View("Sewa");
        }
    }
}
