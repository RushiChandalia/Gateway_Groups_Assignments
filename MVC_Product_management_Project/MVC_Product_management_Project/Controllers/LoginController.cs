using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Product_management_Project.Models;
using NLog;

namespace MVC_Product_management_Project.Controllers
{
    public class LoginController : Controller
    {
        private UsersDBContext db = new UsersDBContext();
        Logger logger = LogManager.GetCurrentClassLogger();

        // GET: Users
        public ActionResult Index()
        {
            return View();
           
        }
        
        [HttpPost]
        public ActionResult Auth(Users UserModel) //POST: Auth() posts the user data to database

        {
            try { 
            var UserDetails = db.Users.Where(x => x.UserName == UserModel.UserName && x.Password == UserModel.Password).FirstOrDefault();
            if (UserDetails == null)
            {
                UserModel.ErrorMessage = "Wrong Username or password";
                return View("Index", UserModel);
            }
            else
            {
                Session["UserId"] = UserDetails.UserId;
                Session["UserName"] = UserDetails.UserName;
                return RedirectToAction("HomeIndex", "Home");
            }
            }
            catch (Exception ex)   //Exception Handling
            {
                logger.Error(ex,"Error occured in Home controller Index Action");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Registration(int id = 0)
        {
            Users userModel = new Users();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult Registration(Users UserModel) //Registered User data is saved to data base  
        {
            using (UsersDBContext db = new UsersDBContext())
            try{
                db.Users.Add(UserModel);
                db.SaveChanges();
                Session["Username"] = UserModel.UserName;
            }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            ModelState.Clear();
            return RedirectToAction("HomeIndex", "Home");
        }
    }
}
