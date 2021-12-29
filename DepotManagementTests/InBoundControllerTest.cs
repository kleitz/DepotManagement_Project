using Contracts;
using DepotManagement.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.JsonPatch;
using SystemManagementService.Models;
using Moq;
using Repository;
using Microsoft.AspNetCore.Mvc;
using DepotManagement.Models;

namespace DepotManagementTests
{
    public class InBoundControllerTest
    {
        private readonly InBoundOperationController _controller;
        private readonly IInBoundRepo _inBoundRepo;
        public InBoundControllerTest()
        {
            var loggerMock = new Mock<ILogger<InBoundOperationController>>();
            _inBoundRepo = new InBoundRepoFake();
            _controller = new InBoundOperationController(_inBoundRepo, loggerMock.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            ProductBundles testItem = new ProductBundles()
            {
                ProductId = 1,
                Quantity = 22
            };
            // Act
            var okResult = _controller.ItemsQuantites();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ItemsQuantites()
        {
            // Act
            var okResult = _controller.ItemsQuantites() as OkObjectResult;
            // Assert
            var items=Assert.IsType<ProductBundles>(okResult.Value);
            Assert.Equal(22, items.Quantity);
        }
        [Fact]
        public void VerifyOrderId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.VerifyOrderId(5);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void VerifyOrderId_ReturnsOkResult()
        {
            // Arrange
            int id = 3;
            // Act
            var okResult = _controller.VerifyOrderId(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void VerifyOrderId_ReturnsRightItem()
        {
            // Arrange
            int id = 2;
            // Act
            var okResult = _controller.VerifyOrderId(id) as OkObjectResult;
            // Assert
            Assert.IsType<InBoundOrders>(okResult.Value);
            Assert.Equal(id, (okResult.Value as InBoundOrders).InOrderId);
        }
    }
}
