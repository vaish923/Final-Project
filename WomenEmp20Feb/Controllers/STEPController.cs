using Microsoft.AspNetCore.Mvc;
using WomenEmp20Feb.Models;
using System.Linq;
namespace WomenEmp20Feb.Controllers
{
    public class STEPController : Controller
    {
        private readonly WomenEmpowerment21Context db;
        private ISession Session;

        public STEPController(WomenEmpowerment21Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            /*ViewBag.Session = HttpContext.Session.GetString("Username");
            ViewBag.Session = HttpContext.Session.GetString("userid");*/
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
            ViewBag.Session = HttpContext.Session.GetString("userid");
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult FAQ()
        {
            ViewBag.Session = HttpContext.Session.GetString("userid");
            ViewBag.Session = HttpContext.Session.GetString("Username");
            return View();
        }

       
        public IActionResult CourseList2()
        {
            return View(db.Courses.ToList().Where(a => a.Approvedstatus == "approved"));
        }

        #region Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }
        #endregion

        #region Enroll
        /* [HttpGet]
         public IActionResult Enroll()

         {
             var wid = HttpContext.Session.GetString("userid");
             if (wid == null)
             {
                 return RedirectToAction("Login", "Main");
             }
             else
             {
                 return View();
             }
         }

         [HttpPost]*/
        [HttpGet]
        public IActionResult CourseList()
        {
            return View(db.Courses.ToList().Where(a => a.Approvedstatus == "approved"));
        }

        [HttpPost]
        public IActionResult CourseList(int id)
        {
                var newid = id;
                var wid = HttpContext.Session.GetString("userid");
                if (wid == null)
                {
                    return RedirectToAction("Login", "Main");
                }
                else
                {
                    Course cid = db.Courses.Find(id);
                    Enrollment e = new Enrollment();
                    e.CourseId = cid.CourseId;
                    e.WomenId = Convert.ToInt32(wid);
                    e.Enrollmentdate = DateTime.Today;
                    e.ApprovalStatus = "pending";
                    e.ApprovalDate = DateTime.Today;

                    db.Enrollments.Add(e);
                    db.SaveChanges();
                    return View("EnrollmentStatus", "STEP");
                }

        }
        
        public IActionResult Enroll(int id)

           
        {
            var newid = id;
            var wid = HttpContext.Session.GetString("userid");
            if (wid == null)
            {
                return RedirectToAction("Login","Main");
            }
            else {
                Course cid = db.Courses.Find(id);
                Enrollment e = new Enrollment();
                e.CourseId = cid.CourseId;
                e.WomenId = Convert.ToInt32(wid);
                e.Enrollmentdate = DateTime.Today;
                e.ApprovalStatus = "pending";
                e.ApprovalDate= DateTime.Today;

                db.Enrollments.Add(e);
                db.SaveChanges();
                return View("Index", "STEP");
            }

        }

        #endregion

      /*  public IActionResult Order()
        {
            // cid = "VINET";
            // var result = db.CustOrdersOrders.FromSqlRaw("[dbo].[CustOrdersOrders] @p0", parameters: new[] { cid });
            return View();
        }
        [HttpPost]
        public IActionResult Order(IFormCollection frm)
        {

            // cid = "VINET";
            string cid = frm["cid"].ToString();
            var customer = db.Customers.Find(cid);
            ViewBag.CustomerId = customer.CustomerId;
            ViewBag.ContactName = customer.ContactName;
            ViewBag.CompanyName = customer.CompanyName;
            var result = db.CustOrdersOrders.FromSqlRaw("[dbo].[CustOrdersOrders] @p0", parameters: new[] { cid });
            return View(result);
        }
        public IActionResult Sales()
        {
            var result = db.SalesByCategories.FromSqlRaw("[dbo].[SalesByCategory] @p0", "BEVERAGES");
            //foreach (var item in result)
            //{
            // item.CategoryName = "BEVERAGES";
            // item.CategoryId = 1;
            //}
            return View(result);
        }*/

        #region Women Details Registration

        [HttpGet]
        public IActionResult WomanDetails()
        {
            var wid = HttpContext.Session.GetString("userid");
            if (wid == null)
            {
                return RedirectToAction("Login", "Main");
            }
            else
            {
               // var enroll = db.getAllEnrollmentsById(Convert.ToInt32(wid)).ToList();
                /* var coursedata = db.getCourseById(id).FirstOrDefault();*/
               // ViewBag.Status = (enroll.FirstOrDefault().approval_status);
               // return View(enroll);
                var w = db.Women.Where(a => a.WomenId == Convert.ToInt32(wid));
                return View(w);

               /* var w = db.Women.Where(a=>a.WomenId==Convert.ToInt32(wid));
                return View(w);*/
            }
        }


        [HttpPost]

        public IActionResult WomanDetails(Woman w)
        {
            var wid = HttpContext.Session.GetString("userid");
            if (wid == null)
            {
                return RedirectToAction("Login", "Main");
            }
            else
            {
                Woman wom = new Woman();
                wom.WomenAddress = w.WomenAddress;
                wom.WomenCity = w.WomenCity;
                wom.WomenState = w.WomenState;
                wom.WomenFathername = w.WomenFathername;
                wom.WomenMothername = w.WomenMothername;
                wom.WomenSpousename = w.WomenSpousename;
                wom.WomenDocument = w.WomenDocument;
                wom.WomenMaritalStatus = w.WomenMaritalStatus;

                db.Women.Add(wom);
                db.SaveChanges();
                return RedirectToAction("Index","STEP");
            }
        }


        #endregion


        #region Enrollment Status Checking
        public IActionResult EnrollmentStatus()
        {
            var wid = HttpContext.Session.GetString("userid");
          
            if (wid == null)
            {
                return RedirectToAction("Login", "Main");
            }

            // var ngodata =db.ngoes.Find(id);

            // var ngodata2 = db.Enrollments.Where(a => a.WomenId == Convert.ToInt32(wid));

            var ngodata2 = (from e in db.Enrollments
                           join c in db.Courses on e.CourseId equals c.CourseId
                           join w in db.Women on e.WomenId equals w.WomenId
                           where w.WomenId== Convert.ToInt32(wid)
                            select new
                           {
                              Women_name= w.WomenFullName,
                              CourseName= c.CourseName,
                             Date=  e.Enrollmentdate,

                             ApprovalStatus=  e.ApprovalStatus,
                                ApprovalDate=  e.ApprovalDate
                           }).ToList();

            
            ViewBag.Status = ngodata2;
            return View(ViewBag.Status);
        }

        #endregion
/*
        [HttpGet]
        public ActionResult GetEnrollmentById(int id)
        {
            var wid = HttpContext.Session.GetString("userid");

            if (wid == null)
            {
                return RedirectToAction("Login", "Main");
            }

            var enrollments = db.Enrollments.Find(id).FirstOrDefault();
                var enroll = db.enrollments.SingleOrDefault(w => w.women_id == id);

                ViewBag.Status = Convert.ToString(enroll.approval_status);
                return View(enrollments);
           

        }*/

    }
}
