using ITDIV.Data;
using ITDIV.Models;
using ITDIV.Models.RentalView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITDIV.Controllers
{
    public class HistoryController : Controller
    {
        private readonly AppDbContext _context;

        public HistoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> History(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("Login", "Account");
            }
            // return View(Cid);

            // var rentalHistory = await _context.TrRental
            // .Where(r => r.customer_id == customerId).ToListAsync();
            var rentalHistory = await _context.TrRental
        .Where(r => r.customer_id == customerId)
        .Join(_context.MsCar,
              rental => rental.car_id,  
              car => car.Car_id,       
              (rental, car) => new
              {
                  rental.rental_date,
                  rental.return_date,
                  rental.total_price,
                  rental.payment_status,
                  CarName = car.name, 
                  perDay = car.price_per_day
              }).ToListAsync();

            var viewModel = rentalHistory.Select(r => new RentalModel
            {
                RentalDate = r.rental_date,
                ReturnDate = r.return_date,
                TotalPrice = r.total_price,
                PaymentStatus = r.payment_status,
                CarName = r.CarName,
                Price_per_day = r.perDay
            }).ToList();

            return View("History", viewModel); 


        }
        public IActionResult Index()
        {
            return View("History");
        }
    }
}
