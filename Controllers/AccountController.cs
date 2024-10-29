using ITDIV.Data;
using ITDIV.Models;
using ITDIV.Models.Register;
using ITDIV.Models.RegisterModel;
using ITDIV.Views.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using RegisterModel = ITDIV.Models.RegisterModel.RegisterModel;

namespace ITDIV.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        private readonly AppDbContext appDbContext;

        public AccountController(AppDbContext appdbcontext)
        {
            this.appDbContext = appdbcontext;
        }
        // Login
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            // Check if user exists and password is correct
            var user = await appDbContext.MsCustomer
                .FirstOrDefaultAsync(u => u.email == userName && u.password == password); // Use hashing for production!

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // Set user information in session or authentication cookie
            HttpContext.Session.SetString("UserName", user.name);
            HttpContext.Session.SetString("Customer_id", user.Customer_id);

            // Redirect to the home page or wherever you want
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register1Model regist)
        {
            var customerId = await GenerateCustomerIdAsync();
            var license = await GenerateCustomerLicense();
            var register = new MsCustomer()
            {
                Customer_id = customerId,
                email = regist.Email,
                password = regist.Password,
                name = regist.FullName,
                phone_number = regist.Phone_number,
                address = regist.Address,
                driver_license_number = license
            };
            await appDbContext.MsCustomer.AddAsync(register);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        private async Task<string> GenerateCustomerIdAsync()
        {
            // Get the current number of customers
            var customerCount = await appDbContext.MsCustomer.CountAsync();
            return $"CUS{customerCount + 1:D3}";
        }
        private async Task<string> GenerateCustomerLicense()
        {
            // Get the current number of customers
            var customerCount = await appDbContext.MsCustomer.CountAsync();
            return $"DLN{customerCount + 1:D3}";
        }



    }
}
