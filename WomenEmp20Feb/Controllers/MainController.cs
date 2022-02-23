using Microsoft.AspNetCore.Mvc;
using WomenEmp20Feb.Models;

namespace WomenEmp20Feb.Controllers
{

    public class MainController : Controller
    {
        private readonly WomenEmpowerment21Context db;
        private ISession Session;

        public MainController(WomenEmpowerment21Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

        #region Registeration of Women
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(Woman w)
        {
          
                db.Women.Add(w);
                db.SaveChanges();
                
           
            ViewBag.message = "Successfully stored";
            return RedirectToAction("Login", "Main");


        }

        #endregion

        #region login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {

            Woman w = new Woman();
             var user = (from userlist in db.Women where userlist.WomenEmail == login.Email && userlist.WomenPassword == login.Password
                         select new
                         {
                             userlist.WomenId,
                             userlist.WomenEmail,
                             userlist.WomenFullName
                         }).ToList();
            if (user.FirstOrDefault() != null)
            {

                //var wom= db.Women.Single(s => s.WomenId == user.Single().WomenId);
                // ViewBag.unique = wom.WomenId;

                //var username = user.FirstOrDefault();
                // TempData["userid"] = user.FirstOrDefault().WomenId;
                //TempData.Keep("userid");
                var id = user.FirstOrDefault().WomenId;
                var name = user.FirstOrDefault().WomenFullName;
                HttpContext.Session.SetString("Username", name);
                HttpContext.Session.SetString("userid", id.ToString());
               // HttpContext.Session.SetString("Username2", "nargis2");

              //  HttpContext.Session.SetString("Username3", "nargis3");
                //  ViewBag.Session = HttpContext.Session.GetString("Username");
                // ISession session;
                //session["username"] = id;
                // HttpContent.Session.SetString();

                //Session["UserName"] = user.FirstOrDefault().WomenEmail;
                // Session["UserID"] = user.FirstOrDefault().WomenId;
                return RedirectToAction("Index", "Step");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials.");
            }
            
            return View(login);
    }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
            TempData["userid"] = null;
        }

        #endregion

    }
}
