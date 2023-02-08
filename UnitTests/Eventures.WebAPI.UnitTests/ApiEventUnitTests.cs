using System;
using System.Linq;
using System.Net;

using Eventures.Data;
using Eventures.Tests.Common;
using Eventures.WebAPI.Controllers;
using Eventures.WebAPI.Models.Event;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Eventures.WebAPI.Models;

namespace Eventures.WebAPI.UnitTests
{
    public class ApiEventUnitTests : ApiUnitTestsBase
    {
        EventsController eventsController;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.eventsController = new EventsController(this.dbContext);
        }

        [Test]
        public void Test_Put_ValidId()
        {
            //set UserMaria as logged in
            TestingUtils.AssignCurrentUserForController(
                this.eventsController, this.testDb.UserMaria);

            //create event in db
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

            //create event binding model
            var changedEvent = new EventBindingModel()
            {
                Name = "House Party" + DateTime.Now.Ticks,
                Place = newEvent.Place,
                Start = newEvent.Start,
                End = newEvent.End,
                TotalTickets = newEvent.TotalTickets,
                PricePerTicket = newEvent.PricePerTicket
            };

            //invoke method 
            var result = this.eventsController.PutEvent(newEvent.Id, changedEvent)
                as NoContentResult;
            Assert.IsNotNull(result);

            //check if no content returned
            Assert.AreEqual((int)HttpStatusCode.NoContent, result.StatusCode);

            //check in db for event name
            var newEventFromDb = this.dbContext.Events.Find(newEvent.Id);
            Assert.AreEqual(newEventFromDb.Name, changedEvent.Name);
        }

        [Test]
        public void Test_Put_InvalidId()
        {
            //create event binding model
            var changedEvent = new EventBindingModel();

            //create invalid id
            var invalidId = -3;

            //invoke method PutEvent
            var result = this.eventsController.PutEvent(invalidId, changedEvent)
                as NotFoundObjectResult;
            Assert.IsNotNull(result);

            //check status code
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);

            //check message
            var resultValue = result.Value as ResponseMsg;
            Assert.AreEqual($"Event #{invalidId} not found.", resultValue.Message);
        }

        [Test]
        public void Test_Delete_ValidId()
        {
            //set UserMaria as logged in
            TestingUtils.AssignCurrentUserForController(
                this.eventsController, this.testDb.UserMaria);

            //create event in db for deleting
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

            //get events cont before delete
            int eventsCountBefore = this.dbContext.Events.Count();

            //invoke method
            var result = this.eventsController.DeleteEvent(newEvent.Id) as OkObjectResult;
            Assert.IsNotNull(result);

            //check ok status code
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);

            var resultValue = result.Value as EventListingModel;
            Assert.IsNotNull(resultValue);
            Assert.AreEqual(resultValue.Id, newEvent.Id);
            Assert.AreEqual(resultValue.Name, newEvent.Name);
            Assert.AreEqual(resultValue.Place, newEvent.Place);

            //check if event is deleted from db
            int eventsCountAfter = this.dbContext.Events.Count();
            Assert.AreEqual(eventsCountBefore - 1, eventsCountAfter);
            Assert.IsNull(this.dbContext.Events.Find(newEvent.Id));
        }

        [Test]
        public void Test_Delete_InvalidId()
        {
            //set UserMaria as logged in
            TestingUtils.AssignCurrentUserForController(
                this.eventsController, this.testDb.UserMaria);

            int invalidId = -3;

            //invoke method with invalid id
            var result = this.eventsController.DeleteEvent(invalidId) as NotFoundObjectResult;
            Assert.IsNotNull(result);

            //check if not found message is returned
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
            var resultValue = result.Value as ResponseMsg;
            Assert.AreEqual($"Event #{invalidId} not found.", resultValue.Message);
        }
    }
}
