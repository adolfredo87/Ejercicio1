using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlquileresMVC;
using AlquileresMVC.Controllers;

namespace AlquileresMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            ViewDataDictionary viewData = result.ViewData;
        }

        [TestMethod]
        public void About()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.About() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
        }
    }
}
