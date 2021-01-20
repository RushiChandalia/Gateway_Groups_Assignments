using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Product_management_Project;
using MVC_Product_management_Project.Controllers;
using MVC_Product_management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Product_management_Project_Tests
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void Index()
        {
            LoginController controller = new LoginController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
      
        [TestMethod]
        public void Registration()
        {
            LoginController controller = new LoginController();
            ViewResult result = controller.Registration() as ViewResult;
            Assert.IsNotNull(result);
        }
     

    }
}
