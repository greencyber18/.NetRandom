using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioRevised.Controllers
{
    public class NewStudentController : Controller
    {
        // GET: NewStudent
        public ActionResult StController()
        {
            ViewBag.Names = "Rafshan";
            return View();
        }
    }
}