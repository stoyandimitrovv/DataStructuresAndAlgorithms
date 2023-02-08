using System.Linq;

using Eventures.Tests.Common;
using Eventures.WebApp.Models;
using Eventures.WebApp.Controllers;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.WebApp.UnitTests
{
    public class HomeControllerTests : UnitTestsBase
    {
        private HomeController controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Instantiate the controller class with the db context
            this.controller = new HomeController(this.dbContext);
        }

        [Test]
        public void Test_Index()
        {           
            TestingUtils.AssignCurrentUserForController(
                this.controller, this.testDb.UserMaria);

            var result = this.controller.Index();

            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            var resultModel = viewResult.Model as HomeViewModel;

            Assert.AreEqual(this.dbContext.Events.Count(),
                resultModel.AllEventsCount);
        }

        [Test]
        public void Test_Error()
        {
            //invoke method
            var result = this.controller.Error();

            //check if returned
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }

        [Test]
        public void Test_Error401()
        {
            //invoke method
            var result = this.controller.Error401();

            //check if returned
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }

        [Test]
        public void Test_Error404()
        {
            //invoke method
            var result = this.controller.Error404();

            //check if returned
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}
