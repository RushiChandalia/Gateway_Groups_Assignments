using MVC_Product_management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Product_management_Project.Controllers
{
    public class HomeController : Controller
    {
        private ProductsDBContext db = new ProductsDBContext();
        // GET: Home
        public ActionResult HomeIndex()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult productList()
        {
            var Products = from e in db.Products
                           orderby e.ProductId
                           select e;
            return View(Products);
        }
        [HttpPost]
        public ActionResult AddProduct(Products pro)
        {
            try
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("productList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = db.Products.Single(m => m.ProductId == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = db.Products.Single(m => m.ProductId == id);
                if (TryUpdateModel(employee))
                {
                    //To Do:- database code
                    db.SaveChanges();
                    return RedirectToAction("productList");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }



    }
}