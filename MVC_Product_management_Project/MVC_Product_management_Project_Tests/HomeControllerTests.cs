using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Product_management_Project;
using MVC_Product_management_Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Product_management_Project_Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeIndex()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.HomeIndex() as ViewResult;
            Assert.IsNotNull(result);
        }

    }
}
