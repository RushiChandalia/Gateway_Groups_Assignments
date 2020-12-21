﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Product_management_Project.Models;

namespace MVC_Product_management_Project.Controllers
{
    public class LoginController : Controller
    {
        private UsersDBContext db = new UsersDBContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(Users UserModel)
        {
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
        [HttpGet]
        public ActionResult Registration(int id = 0)
        {
            Users userModel = new Users();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult Registration(Users UserModel)
        {
            using (UsersDBContext db = new UsersDBContext())
            {
                db.Users.Add(UserModel);
                db.SaveChanges();
                Session["Username"] = UserModel.UserName;
            }
            ModelState.Clear();
            return RedirectToAction("HomeIndex", "Home");
        }
    }
}