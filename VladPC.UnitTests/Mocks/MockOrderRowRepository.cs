using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.UnitTests.Mocks
{
    public static class MockOrderRowRepository
    {
        public static List<OrderRow> OrderRows = new List<OrderRow>()
        {
            new OrderRow() { Id = 1, OrderId = 1, ProductId = 1, Price = 6599, Count = 1 },
            new OrderRow() { Id = 2, OrderId = 2, ProductId = 6, Price = 8499, Count = 1 },
            new OrderRow() { Id = 3, OrderId = 3, ProductId = 5, Price = 47999, Count = 1 },
            new OrderRow() { Id = 4, OrderId = 4, ProductId = 2, Price = 7899, Count = 10 },
        };

        public static Mock<IRepository<OrderRow>> GetMock()
        {
            var mock = new Mock<IRepository<OrderRow>>();

            mock.Setup(m => m.GetList()).Returns(() => OrderRows);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => OrderRows.FirstOrDefault(o => o.Id == id) ?? OrderRows[0]);
            mock.Setup(m => m.Create(It.IsAny<OrderRow>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<OrderRow>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
