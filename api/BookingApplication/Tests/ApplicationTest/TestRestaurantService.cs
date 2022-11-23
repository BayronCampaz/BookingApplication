using Application.Services;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.RequestModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApplicationTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Create_A_Valid_Restaurant()
        {
            // Arrange
            var mockRestaurantRepository = new Mock<IRestaurantRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockValidator = new Mock<IValidator<RestaurantRequest>>();
            var restaurantService = new RestaurantService(mockRestaurantRepository.Object, mockMapper.Object, mockValidator.Object);
            var restauranRequest = new RestaurantRequest();
            
            // Act
            var result = await restaurantService.Create(restauranRequest);

            // Assert
            Assert.That(restauranRequest.Name, Is.EqualTo(result.Name));
            Assert.That(restauranRequest.Address, Is.EqualTo(result.Address));
            Assert.That(restauranRequest.City, Is.EqualTo(result.City));
        }

        [Test]
        public async Task Create_A_Invalid_Restaurant_Throws_Exception()
        {
            // Arrange
            var mockRestaurantRepository = new Mock<IRestaurantRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockValidator = new Mock<IValidator<RestaurantRequest>>();
            var restaurantService = new RestaurantService(mockRestaurantRepository.Object, mockMapper.Object, mockValidator.Object);
            var restauranRequest = new RestaurantRequest();

            // Act + Assert
            Assert.Throws<Exception>(() => restaurantService.Create(restauranRequest));
        }
    }
}