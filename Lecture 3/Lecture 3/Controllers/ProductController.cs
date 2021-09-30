using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lecture_3.Models;

namespace Lecture_3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var Product = db.Product.GetAll();
            return View(Product);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p) {
            if (ModelState.IsValid) {
                Database db = new Database();
                db.Product.Add(p);
               

                return RedirectToAction("Index");
            }
            return View();
            
        }

        

    }
}