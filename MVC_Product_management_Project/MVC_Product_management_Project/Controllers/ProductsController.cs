using MVC_Product_management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_Product_management_Project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<mvcProduct> productList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<mvcProduct>>().Result;
            return View(productList);
        }
        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            return View(new mvcProduct());
        }
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }
    }
}