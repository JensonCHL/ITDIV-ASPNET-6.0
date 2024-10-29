using ITDIV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITDIV.Controllers
{
    public class GetCar : Controller
    {
        private readonly AppDbContext appDbContext;

        public GetCar(AppDbContext appdbcontext)
        {
            this.appDbContext = appdbcontext;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {   
            var employees = await appDbContext.MsCar.ToListAsync();
            return View("carsview",employees);
        }
    }
}
