using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using Core.Interfaces;
using Core.Models;
using IO.Swagger.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{

    public class LoginApiControllerTests
    {
        [Fact]
        public void Login_ValidUser_ReturnsOkResultWithToken()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var mockConfiguration = new Mock<IConfiguration>();
            var user = new UserModel { Username = "Test", Password = "Test" };
            var token = "testToken";

            mockUserService.Setup(service => service.AuthenticateUser(It.IsAny<UserModel>())).Returns(user);
            mockUserService.Setup(service => service.GenerateJSONWebToken(user, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(token);
            mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("testKey");
            mockConfiguration.Setup(config => config["Jwt:Issuer"]).Returns("testIssuer");

            var controller = new LoginApiController(mockUserService.Object, mockConfiguration.Object);

            // Act
            var result = controller.Login(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Dictionary<string, string>>(okResult.Value);
            Assert.False(string.IsNullOrEmpty(returnValue["token"]));
        }
    }
}