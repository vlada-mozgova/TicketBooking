using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTicketBooking.Models;

namespace WebTicketBooking.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        // Method for getting the Username of an authorized user
        public string GetUser()
        {
            string userName = User.Identity.Name;
            return userName;
        }

        // Initial display method
        public IActionResult Index()
        {
            return View();
        }

        // Privacy display method
        public IActionResult Privacy()
        {
            return View();
        }

        // Error display method
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
