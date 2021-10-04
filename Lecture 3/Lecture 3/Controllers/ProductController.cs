using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lecture_3.Models;
using System.Web.Script.Serialization;

namespace Lecture_3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var Product = db.Products.GetAll();
            return View(Product);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products p) {
            if (ModelState.IsValid) {
                Database db = new Database();
                db.Products.Add(p);


                return RedirectToAction("Index");
            }
            return View();


        }
        /*
        [HttpGet]
        public ActionResult AddCart(int ID)
          {
              List<Products> products = null;
              Database db = new Database();
              var product = db.Products.GetID(ID);

              if (Session["AddCart"] == null)
              {
                  products = new List<Products>();
                  products.Add(product);
                  string json = new JavaScriptSerializer().Serialize(product);
                  Session["AddCart"] = json;
                  return View(product);
              }
              else
              {
                  var p = Session["AddCart"].ToString();
                  products = new JavaScriptSerializer().Deserialize<List<Products>>(p);
                  products.Add(product);
                  string json = new JavaScriptSerializer().Serialize(products);
                  Session["AddCart"] = json;
                  return View(products);
              }
          }

          [HttpPost]
          public ActionResult AddCart()
          {
              List<Products> products = new List<Products>();
              var p = Session["AddCart"].ToString();
              products = new JavaScriptSerializer().Deserialize<List<Products>>((string)p);

              Database db = new Database();

              Session["AddCart"] = null;

              return RedirectToAction("Index");
          } */


        public ActionResult delete(int ID)
        {
            Database db = new Database();
            db.Products.delete(ID);
            return RedirectToAction("Index");
        }
    }



}