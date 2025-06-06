using Microsoft.EntityFrameworkCore.Storage.Json;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;
using VladPC.DAL.Interfaces;
using VladPC.UnitTests.Mocks;

namespace VladPC.UnitTests
{
    public class OrderServiceTest
    {
        Mock<IDbRepos> uowMock;
        IOrderService orderService;
        IProductService productService;

        public OrderServiceTest()
        {
            uowMock = MockUowRepository.GetMock();
            productService = new ProductService(uowMock.Object);
            orderService = new OrderService(uowMock.Object, productService);
        }

        [Fact]
        public void AddProductToOrder_Success()
        {
            bool result = orderService.AddProductToOrder(1, 1, Common.Status.InCart);
            Assert.True(result);
        }

        [Fact]
        public void GetCart_Success()
        {
            var cart = orderService.GetCart(1, Common.Status.InCart);
            Assert.Equal(cart.Id, 4);

            cart = orderService.GetCart(1, Common.Status.InConfigurator);
            Assert.Equal(cart.Id, 3);
        }

        [Fact]
        public void SetOrder_Success()
        {
            bool result = orderService.SetOrder(1);
            Assert.True(result);
        }

        [Fact]
        public void GetOrderHistory_Success()
        {
            var orders = orderService.GetOrderHistory(1);
            Assert.Equal(orders.Count, 3);
        }

        [Fact]
        public void GetUserOrders_Success()
        {
            var orders = orderService.GetUserOrders();
            Assert.Equal(orders.Count, 1);
        }

        [Fact]
        public void CompliteOrder_Success()
        {
            Assert.True(orderService.CompliteOrder(2));
        }

        [Fact]
        public void GetOrderRows_Success()
        {
            var orderRows = orderService.GetOrderRows(1);
            Assert.Equal(orderRows.Count, 1);
        }

        [Fact]
        public void ApplyPromocode_Success()
        {
            bool result = orderService.ApplyPromocode(1, "SALE20");
            Assert.True(result);
        }

        [Fact]
        public void AddConfigurationToCart_Failed()
        {
            bool result = orderService.AddConfigurationToCart(1);
            Assert.False(result);
        }

        [Fact]
        public void GetPromocode_Success()
        {
            var promocode = orderService.GetPromocode(1);
            Assert.Equal(promocode.Code, "SALE20");
        }
    }
}
