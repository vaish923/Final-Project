using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WomenEmp20Feb.Models;


namespace WomenEmp20Feb.Controllers
{
    public class NGOController : Controller
    {
        private readonly WomenEmpowerment21Context db;
        private ISession Session;

        public NGOController(WomenEmpowerment21Context context)
        {
            db = context;
        }
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

        #region NGO Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(Ngo ngo)
        {
            db.Ngos.Add(ngo);
            db.SaveChanges();

            ViewBag.message = "Successfully stored";
            return RedirectToAction("NGOLogin", "NGO");

        }

        #endregion 

        #region login

        [HttpGet]
        public IActionResult NGOLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NGOLogin(Login login)
        {

            Ngo n = new Ngo();
            var user = (from userlist in db.Ngos
                        where userlist.NgoEmail == login.Email && userlist.NgoPassword == login.Password
                        select new
                        {
                            userlist.NgoId,
                            userlist.NgoEmail,
                            userlist.NgoName,
                            userlist.Approvedstatus
                        }).ToList();
            if (user.FirstOrDefault() != null)
            {


                var id = user.FirstOrDefault().NgoId;
                var name = user.FirstOrDefault().NgoName;
                var status = user.FirstOrDefault().Approvedstatus;
                //  HttpContext.Session.SetString("Username", name);
                HttpContext.Session.SetString("NGOid", id.ToString());
                HttpContext.Session.SetString("status", status);

                return RedirectToAction("Index", "NGO");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials.");
            }

            return View("NGOLogin");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("NGOid");
            HttpContext.Session.Remove("status");
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult NGOFunding()
        {
            return View();
        }
        /*#region NGO by id

        [HttpGet]
        public ActionResult GetNgoById(int id, Ngo ngo)
        {
            var Nid = HttpContext.Session.GetString("NGOid");

            if (Nid == null)
            {
                return RedirectToAction("Login", "NGO");
            }

            // var ngodata =db.ngoes.Find(id);
            var ngodata = db.Ngos.Find(id);
            //ViewBag.Status = ngodata.Approvedstatus;
            return View(ngodata);

        }
        [HttpPost]
        public ActionResult GetNgoById(Ngo ngo, int id)
        {
            var Nid = HttpContext.Session.GetString("NGOid");
            if (Nid == null)
            {
                return RedirectToAction("Login", "NGO");
            }

            Ngo ngodata = db.Ngos.Find(id);
            //ViewBag.Status = ngodata.Approvedstatus;
           
                return View(ngodata);
           
        }

    }
    #endregion*/

        #region for getting NGO status
        public ActionResult GetNgoByIdStatus()
        {
            var Nid = HttpContext.Session.GetString("NGOid");

            if (Nid == null)
            {
                return RedirectToAction("NGOLogin", "NGO");
            }

            // var ngodata =db.ngoes.Find(id);
            var ngodata = db.Ngos.Find(Convert.ToInt32(Nid));
            //ViewBag.Status = ngodata.Approvedstatus;
            return View(ngodata);

        }
        [HttpPost]
        public ActionResult GetNgoById(Ngo ngo, int id)
        {
            var Nid = HttpContext.Session.GetString("NGOid");
            if (Nid == null)
            {
                return RedirectToAction("Login", "NGO");
            }

            Ngo ngodata = db.Ngos.Find(id);
            //ViewBag.Status = ngodata.Approvedstatus;

            return View(ngodata);

        }
        #endregion

        #region
        public IActionResult NGOList()
        {
            return View(db.Ngos.ToList().Where(a => a.Approvedstatus == "approved"));
        }

        #endregion

        #region
        public IActionResult CourseList()
        {
            return View(db.Courses.ToList().Where(a => a.Approvedstatus == "approved"));
        }

        #endregion

        #region Edit Women details

        [HttpGet]

        public IActionResult Edit()

        {
            var wid = HttpContext.Session.GetString("NGOid");
            return View(db.Ngos.Find(Convert.ToInt32(wid)));
        }

        [HttpPost]

        public IActionResult Edit(Ngo n)

        {

            Ngo ngo = db.Ngos.Find(n.NgoId);

            ngo.NgoName = n.NgoName;
            ngo.ContactPerson = n.ContactPerson;
            ngo.NgoContactNumber = n.NgoContactNumber;
            ngo.NgoEmail = n.NgoEmail;
            ngo.NgoAddress = n.NgoAddress;
            ngo.NgoCity = n.NgoCity;
            ngo.NgoState = n.NgoState;
            ngo.NgoPassword = n.NgoPassword;
            ngo.NgoSupportingdocument = n.NgoSupportingdocument;
            ngo.NgoDescription = n.NgoDescription;

            if (n.Approvedstatus == "approved")
            {
                ngo.Approvedstatus = n.Approvedstatus;
            }
            else
            {
                ngo.Approvedstatus = "pending";
            }
          /*  ngo.Status = n.Status;
            ngo.Approvedstatus = n.Approvedstatus;
*/


            db.SaveChanges();
            return RedirectToAction("GetNgoByIdStatus", "NGO");
           // return View("Index");


        }


        #endregion


        #region Course Adding
        // GET: Orders/Create

        [HttpGet]
        public IActionResult Create()
        {

            /* List<Trainer> trainer  = db.Trainers.ToList();
              ViewData["trainer"] = trainer;*/
            // ViewBag.data = db.Trainers.ToList();

            // List<SelectListItem> mySkills = new List<SelectListItem>();
            /* mySkills = db.Trainers.ToList();*/
            /* if (items != null)
             {
                 ViewBag.data = items;
             }
             var items2 = db.Coursecategories.ToList();
             if (items2 != null)
             {
                 ViewBag.data2 = items2;
             }*/


            /* ViewBag.model1= new SelectList(db.Trainers, "trainer_id", "trainer_full_name");

              var lstskill = (from a in db.Trainers orderby a.Courses select a).ToList();

                    ViewBag.SkillListItem =new  SelectList(lstskill);*/
            // var model2 = new SelectList(db.Coursecategories, "category_id", "category_name");
            // ViewBag.TrainerId = new SelectList(db.Trainers.ToList(), "trainer_id", "trainer_full_name");

            //  ViewBag.CourseCategory = new SelectList(db.Coursecategories.ToList(), "category_id", "category_name");

            /*   List<Coursecategory> category = db.Coursecategories.ToList();
               ViewData["category"] = category;*/
            var courses = new Course();
            return View(courses);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Course c)
        {
            // ViewData["TrainerId"] = new SelectList(db.Trainers, "trainer_id", "trainer_full_name", c.TrainerId);

            //  ViewData["category_name"] = new SelectList(db.Coursecategories, "category_id", "category_name", c.Coursecategory);
            if (ModelState.IsValid)
            {
                db.Add(c);
                db.SaveChangesAsync();
            }
            ModelState.Clear();

            ViewBag.SuccessMessage = "Course added";
            return View(c);
        }


        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "ShipperId", order.ShipVia);
            return View(order);
        }*/


        #endregion
        /* [HttpPost]
     public IActionResult Create(Course c)
     {
         db.Courses.Add(c);
         db.SaveChanges();
         return View(Index);
     }*/
    }




}



