using SourceControlFinalAssingment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SourceControlFinalAssingment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Auth(SourceControlFinalAssingment.Models.UserTable UserModel)
        {
            using (Model1 db = new Model1())
            {
                var UserDetails = db.UserTables.Where(x => x.UserName == UserModel.UserName && x.Password == UserModel.Password).FirstOrDefault();
                if(UserDetails == null)
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
          
        }
        [HttpGet]
        public ActionResult Registration(int id = 0)
        {
            UserTable userModel = new UserTable();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult Registration(UserTable UserModel)
        {
            using (Model1 db = new Model1())
            {
                db.UserTables.Add(UserModel);
                db.SaveChanges();
                Session["Username"] = UserModel.UserName;
            }
            ModelState.Clear();
            return RedirectToAction("HomeIndex", "Home");
        }


      
    }
}