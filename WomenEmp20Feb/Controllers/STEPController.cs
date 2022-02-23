using Microsoft.AspNetCore.Mvc;


namespace WomenEmp20Feb.Controllers
{
    public class STEPController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            ViewBag.Session = HttpContext.Session.GetString("id");
           // ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult ContactUs()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult Guidelines()
        {
            ViewBag.Session = HttpContext.Session.GetString("id");
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult FAQ()
        {
            ViewBag.Session = HttpContext.Session.GetString("id");
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
    }
}
