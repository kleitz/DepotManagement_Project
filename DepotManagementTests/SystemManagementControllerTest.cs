using Contracts;
using DepotManagement.Controllers;
using DepotManagement.ModelHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using SystemManagementService.Models;
using Xunit;

namespace DepotManagementTests
{
    public class SystemManagementControllerTest
    {
        private readonly SystemManagementController _controller;
        private readonly ISystemManagementRepo _systemManagementRepo;
        public SystemManagementControllerTest()
        {
            var loggerMock = new Mock<ILogger<SystemManagementController>>();
            _systemManagementRepo = new SystemManagementRepoFake();
            _controller = new SystemManagementController(_systemManagementRepo, loggerMock.Object);
        }
        [Fact]
        public void Task_ProductCreationWithType_OkResult()
        {
            //Act

            ProductHelper _prod = new ProductHelper()
            {
                ProductNumber = "SE1",
                ProductPrice = 200,
                ProductType = "Mobile",
                ProductDescription = "Samsung"
            };

            var createdResponse = _controller.ProductCreationWithType(_prod);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Add_ProductCreationWithType_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            ProductHelper _prod = new ProductHelper()
            {
                ProductNumber = "SE1",
                ProductPrice = 200,
                ProductType = "Mobile",
                ProductDescription = "Samsung"
            };
            // Act
            var createdResponse = _controller.ProductCreationWithType(_prod) as CreatedAtActionResult;
            var item = createdResponse.Value as Products;
            // Assert
            Assert.IsType<Products>(item);
            Assert.Equal("Mobile", item.ProductType);
        }
    }
}
