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
    public static class MockOrderRepository
    {
        public static List<Order> Orders = new List<Order>()
        {
            new Order() { Id = 1, UserId = 1, Status = 3, PromocodeId = null, CreationDate = DateTime.Now.AddDays(-4) },
            new Order() { Id = 2, UserId = 1, Status = 2, PromocodeId = null, CreationDate = DateTime.Now.AddDays(-3) },
            new Order() { Id = 3, UserId = 1, Status = 1, PromocodeId = null, CreationDate = null },
            new Order() { Id = 4, UserId = 1, Status = 0, PromocodeId = null, CreationDate = null },
        };

        public static Mock<IRepository<Order>> GetMock()
        {
            var mock = new Mock<IRepository<Order>>();

            mock.Setup(m => m.GetList()).Returns(() => Orders);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Orders.FirstOrDefault(o => o.Id == id) ?? Orders[0]);
            mock.Setup(m => m.Create(It.IsAny<Order>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Order>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
