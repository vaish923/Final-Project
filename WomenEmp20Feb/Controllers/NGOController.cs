using Microsoft.AspNetCore.Mvc;

namespace WomenEmp20Feb.Controllers
{
    public class NGOController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Legislation()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

       
    }
}
