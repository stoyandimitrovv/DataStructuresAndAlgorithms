using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Eventures.WebAPI.Models;
using Eventures.WebAPI.Controllers;
using Eventures.WebAPI.Models.User;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Eventures.WebAPI.UnitTests
{
    public class ApiUserUnitTests : ApiUnitTestsBase
    {
        UsersController usersController;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Get configuration from appsettings.json file in the Web API project
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            this.usersController = new UsersController(this.dbContext, configuration);
        }

        [Test]
        public async Task Test_User_Register()
        {
            //users count before registration
            var usersBefore = this.dbContext.Users.Count();

            //creating new register model
            var newUser = new RegisterModel()
            {
                Username = "user" + DateTime.Now.Ticks.ToString().Substring(10),
                FirstName = "Peter",
                LastName = "Petrov",
                Email = "pesho.petrov@abv.bg",
                Password = "pass",
                ConfirmPassword = "pass"
            };

            //invoke the method and check 
            var result = await this.usersController.Register(newUser) as OkObjectResult;
            Assert.IsNotNull(result);

            //check if result.StatusCode is the same and also the Message
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            var resultValues = result.Value as ResponseMsg;
            Assert.AreEqual("User created successfully!", resultValues.Message);

            //check if user added to db
            var usersAfter = this.dbContext.Users.Count();
            Assert.AreEqual(usersBefore + 1, usersAfter);
        }

        [Test]
        public async Task Test_User_Register_ExistingUser()
        {
            //get users count
            var usersCount = this.dbContext.Users.Count();

            //get Maria from db
            var userMaria = this.testDb.UserMaria;

            //create new register model
            var newUser = new RegisterModel()
            {
                Username = userMaria.UserName,
                FirstName = userMaria.FirstName,
                LastName = userMaria.LastName,
                Email = userMaria.Email,
                Password = userMaria.PasswordHash,
                ConfirmPassword = userMaria.PasswordHash
            };

            //invoke the method
            var result = await this.usersController.Register(newUser) as BadRequestObjectResult;
            Assert.IsNotNull(result);

            //check if result.StatusCode is the same and also the Message
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
            var resultValues = result.Value as ResponseMsg;
            Assert.AreEqual("User already exists!", resultValues.Message);

            //chek if user not created in db
            var usersAfter = this.dbContext.Users.Count();
            Assert.AreEqual(usersCount, usersAfter);
        }

        [Test]
        public async Task Test_User_Login_ValidCredentials()
        {
            //get Maria from db
            var userMariaUsername = this.testDb.UserMaria.UserName;

            //create login model
            var user = new LoginModel()
            {
                Username = userMariaUsername,
                Password = userMariaUsername
            };

            //invoke method and check 
            var result = await this.usersController.Login(user) as OkObjectResult;
            Assert.IsNotNull(result);

            //check result.StatusCode
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);

            var resultValue = result.Value as ResponseWithToken;
            Assert.IsNotNull(resultValue.Token);
            Assert.AreNotEqual("1/1/0001 12:00:00 AM", resultValue.Expiration);
        }

        [Test]
        public async Task Test_User_Login_InvalidCredentials()
        {
            //get Maria from db
            var userMariaUsername = this.testDb.UserMaria.UserName;

            //create invalid login model
            var user = new LoginModel()
            {
                Username = userMariaUsername,
                Password = "123456Qwerty"
            };

            //invoke method and check, use Unauthorized
            var result = await this.usersController.Login(user) as UnauthorizedObjectResult;
            Assert.IsNotNull(result);

            //check if result.StatusCode is the same and also the Message
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, result.StatusCode);

            var resultValue = result.Value as ResponseMsg;
            Assert.AreEqual("Invalid username or password!", resultValue.Message);
        }
    }
}
