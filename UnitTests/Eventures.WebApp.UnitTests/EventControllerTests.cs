using System.Linq;
using System.Collections.Generic;

using Eventures.WebApp.Models;
using Eventures.WebApp.Controllers;
using Eventures.Tests.Common;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using Eventures.Data;

namespace Eventures.WebApp.UnitTests
{
    public class EventControllerTests : UnitTestsBase
    {
        private EventsController controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Instantiate the controller class with the testing database
            this.controller = new EventsController(this.dbContext);

            // Set UserMaria as current logged user
            TestingUtils.AssignCurrentUserForController(this.controller, this.testDb.UserMaria);
        }

        [Test]
        public void Test_All()
        {
            var result = this.controller.All();

            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            var resultModel = viewResult.Model as List<EventViewModel>;
            Assert.IsNotNull(resultModel);
            Assert.AreEqual(this.dbContext.Events.Count(), resultModel.Count);
        }

        [Test]
        public void Test_Create()
        {
            var result = this.controller.Create();

            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            var resultModel = viewResult.Model as EventBindingModel;
            Assert.IsNotNull(resultModel);
        }

        [Test]
        public void Test_DeletePage_ValidId()
        {
            //add new event in db
            var newEvent = new Event()
            {
                Name = "Beach Party" + DateTime.Now.Ticks,
                Place = "Ibiza",
                Start = DateTime.Now.AddMonths(3),
                End = DateTime.Now.AddMonths(3),
                TotalTickets = 20,
                PricePerTicket = 120.00m,
                OwnerId = this.testDb.UserMaria.Id
            };
            this.dbContext.Add(newEvent);
            this.dbContext.SaveChanges();

            //invoke method
            var result = this.controller.Delete(newEvent.Id);

            //check if view is returned
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            //check the results
            var resultModel = viewResult.Model as EventViewModel;
            Assert.IsNotNull(resultModel);
            Assert.That(resultModel.Id == newEvent.Id);
            Assert.That(resultModel.Name == newEvent.Name);
            Assert.That(resultModel.Place == newEvent.Place);
        }

        [Test]
        public void Test_DeletePage_InvalidId()
        {
            //create invalid id
            var invalidId = -3;

            //try Delete method with the invalid id
            var result = this.controller.Delete(invalidId);

            //make sure bad request is returned
            var badRequest = result as BadRequestResult;
            Assert.IsNotNull(badRequest);

        }

        [Test]
        public void Test_Edit_ValidId()
        {
            //get the event from db
            var devConferenceEvent = this.testDb.EventDevConf;

            //invoke method
            var act = this.controller.Edit(devConferenceEvent.Id);

            //check if view is returned
            var view = act as ViewResult; 
            Assert.IsNotNull(view);

            //check the results
            var resultModel = view.Model as EventBindingModel;
            Assert.IsNotNull(resultModel);
            Assert.AreEqual(resultModel.Name, devConferenceEvent.Name);
            Assert.AreEqual(resultModel.Place, devConferenceEvent.Place);
            Assert.AreEqual(resultModel.Start, devConferenceEvent.Start);
            Assert.AreEqual(resultModel.End, devConferenceEvent.End);
            Assert.AreEqual(resultModel.PricePerTicket, devConferenceEvent.PricePerTicket);
            Assert.AreEqual(resultModel.TotalTickets, devConferenceEvent.TotalTickets);
        }

        [Test]
        public void Test_Edit_InvalidId()
        {
            //create invalid id
            var invalidId = -2;

            //try Edit method with the invalid id
            var act = this.controller.Edit(invalidId);

            //make sure bad request is returned
            var badRequiest = act as BadRequestResult;
            Assert.IsNotNull(badRequiest);
        }
    }
}
