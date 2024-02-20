using CustomerService.API.Controllers;
using CustomerService.API.Models;
using CustomerService.Domain.Entities;
using CustomerService.Domain.Interfaces;
using CustomerService.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CustomerService.Tests.Controllers
{
    public class CustomerServiceControllerTests
    {
        private readonly CustomerServiceController _controller;
        private readonly Mock<IBaseService<ClientEntity>> _mockService;

        public CustomerServiceControllerTests()
        {
            _mockService = new Mock<IBaseService<ClientEntity>>();
            _controller = new CustomerServiceController(_mockService.Object);
        }

        [Fact]
        public void Create_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var user = new CreateClientModel(); // create a valid user object
            _mockService.Setup(x => x.Add<CreateClientModel, ClientModel, CreditValidator>(user)).Returns(new ClientModel());

            // Act
            var result = _controller.Create(user);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Create_NullUser_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.Create(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Similar tests for other action methods (Get, Update, Delete) can be written following the same pattern.
    }
}
