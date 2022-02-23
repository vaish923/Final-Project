using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WomenEmp20Feb.Models;

namespace WomenEmp20Feb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WomenEmpowerment21Context db;

       

       public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult AboutUs()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult ContactUs()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult Legislation()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult FAQ()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult Privacy()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}