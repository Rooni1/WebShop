using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Models.Entities;
using WebShop.Models.Repo;
using WebShop.Models.Service;
using WebShop.ViewModels;
using Xunit;

namespace WebShopTest
{
    public class OrderTest
    {
        private readonly OrderService _testOrderService;
        private readonly Mock<IOrderRepo> _orderrepoMock = new Mock<IOrderRepo>();
        public OrderTest()
        {
            _testOrderService = new OrderService(_orderrepoMock.Object);
        }
        [Fact]
        public void GetOrderByIdTest()
        {
            //Arrange
            int orderId = 10;
           
            var expectedOrder = new Order
            {
                OrderId = orderId,
                OrderDate = DateTime.Now
            };

            _orderrepoMock.Setup(x => x.FindById(orderId)).Returns(expectedOrder);
            //Act
            var actualOrder = _testOrderService.FindBy(orderId);
            //Assert
            Assert.Equal(expectedOrder.OrderId, actualOrder.OrderId);
            Assert.Equal(expectedOrder.OrderDate, actualOrder.OrderDate);
        }

        [Fact]
        public void CreateOrderTest()
        {
            //Arrange
            int orderId = 15;
            var createOrder = new CreateOrderViewModel();
            createOrder.OrderId = orderId;
            createOrder.OrderDate = DateTime.Now;

            var newExpectedOrder = new Order
            {
                OrderId = createOrder.OrderId,
                OrderDate = createOrder.OrderDate
            };

            _orderrepoMock.Setup(x => x.Create(createOrder)).Returns(newExpectedOrder);
            //Act
            var actualOrder = _testOrderService.Add(createOrder);
            //Assert
            Assert.Equal(newExpectedOrder.OrderId, actualOrder.OrderId);
            Assert.Equal(newExpectedOrder.OrderDate, actualOrder.OrderDate);
        }

    }
}
