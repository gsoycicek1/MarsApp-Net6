using MarsRovers.Controllers;
using MarsRovers.Dtos;
using MarsRovers.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MarsRovers.Test.ApiTest
{
    public class ApiResultTest
    {
        private readonly Mock<ICalculateLastCoordinate> _mockRepo;
        private readonly HomeController _controller;

        public ApiResultTest()
        {
            _mockRepo = new Mock<ICalculateLastCoordinate>();
            _controller = new HomeController(_mockRepo.Object);
        }

        [Fact]
        public async void GetLastCoordinate_ActionExecutes_ReturnOkObjectResult()
        {
            #region Test Data
            var product = new InputsFromClientDto
            {
                RoversPosition = "1 2 N",
                UpperRightCoordinates = "5 5",
                Instructions = "LMLMLMLMM"
            };

            var response = new ResponseDto
            {
                IsSuccess = true,
                Error = "",
                Data = "1 3 N"
            };
            #endregion

            _mockRepo.Setup(w => w.GetLastCoordinate(product)).ReturnsAsync(response);

            var result = await _controller.GetLastCoordinate(product);

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<ResponseDto>(okResult.Value);

            Assert.Equal("1 3 N", returnProducts.Data);
        }

    }
}
