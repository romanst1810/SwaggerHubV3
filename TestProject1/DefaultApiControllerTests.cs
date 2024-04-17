using Core.Interfaces;
using Core.Models;
using IO.Swagger.Controllers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Core.Interfaces;
using Core.Models;
using IO.Swagger.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class DefaultApiControllerTests
    {
        [Fact]
        public void CalculatePost_ValidParameters_ReturnsOkResultWithResult()
        {
            // Arrange
            var mockCalcService = new Mock<ICalcService>();
            var body = new CalculateBody { Num1 = 5, Num2 = 3 };
            var operation = "add";
            var resultResponse = new ResultResponce { Result = 8 };

            mockCalcService.Setup(service => service.GetResult(body.Num1, body.Num2, operation))
                .Returns(resultResponse);

            var controller = new DefaultApiController(mockCalcService);

            // Act
            var result = controller.CalculatePost(body, operation);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<InlineResponse2001>(okResult.Value);
            Assert.Equal(resultResponse.Result, returnValue.Result);
        }
    }
}