using MVC_Product_management_Project.Models;
using NLog;
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
        Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Products
        public ActionResult Index()
        {
            try
            {
                IEnumerable<mvcProduct> productList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
                productList = response.Content.ReadAsAsync<IEnumerable<mvcProduct>>().Result;
                return View(productList);
            }
            catch (Exception ex)   //Exception Handling
            {
                logger.Error(ex, "Error occured in Home controller Index Action");

            }
            return View();
        }
       
        public ActionResult Create(int id = 0)
        {
            if(id == 0){
                return View(new mvcProduct());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProduct>().Result);
            }
        }
        [HttpPost]
        public ActionResult Create(mvcProduct prod)
        {
            try
            { 
                     if (prod.Id == 0)
                     {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", prod).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                     }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + prod.Id, prod).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
            }
            catch (Exception ex)   //Exception Handling
            {
                logger.Error(ex, "Error occured in Home controller Index Action");

            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}