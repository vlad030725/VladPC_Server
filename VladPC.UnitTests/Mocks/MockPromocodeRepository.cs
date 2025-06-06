using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.UnitTests.Mocks
{
    public static class MockPromocodeRepository
    {
        public static List<Promocode> Promocodes = new List<Promocode>()
        {
            new Promocode() { Id = 1, Code = "SALE20", Discount = 0.2 },
        };

        public static Mock<IRepository<Promocode>> GetMock()
        {
            var mock = new Mock<IRepository<Promocode>>();

            mock.Setup(m => m.GetList()).Returns(() => Promocodes);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Promocodes.FirstOrDefault(o => o.Id == id) ?? Promocodes[0]);
            mock.Setup(m => m.Create(It.IsAny<Promocode>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Promocode>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
