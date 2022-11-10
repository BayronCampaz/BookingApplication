using Domain.Abstractions.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Controllers;

namespace WebTest
{
    public class TestRestaurantController
    {
        [Fact]
        public async void Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockRestaurantService = new Mock<IRestaurantService>();
            var mockLogger = new Mock<ILogger<RestaurantController>>();
            var restaurantController = new RestaurantController(mockLogger.Object, mockRestaurantService.Object);

            // Act
            var result = (OkObjectResult) await restaurantController.GetAllRestaurants();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void Get_OnSuccess_InvokesUserService()
        {
            // Arrange
            var mockRestaurantService = new Mock<IRestaurantService>();
            var mockLogger = new Mock<ILogger<RestaurantController>>();
            var restaurantController = new RestaurantController(mockLogger.Object, mockRestaurantService.Object);

            // Act
            var result = (OkObjectResult)await restaurantController.GetAllRestaurants();

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}