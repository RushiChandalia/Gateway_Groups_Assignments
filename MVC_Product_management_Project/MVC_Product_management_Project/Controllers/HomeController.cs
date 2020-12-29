﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Product_management_Project.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult ProductList()
        {
            Session.Abandon();
            return RedirectToAction("productList", "Product");
        }
        public ActionResult ProductAdd()
        {
            Session.Abandon();
            return RedirectToAction("productAdd", "Product");
        }
    }
}