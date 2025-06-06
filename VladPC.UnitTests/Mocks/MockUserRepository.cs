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
    public static class MockUserRepository
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Id = 1, UserName = "test1" },
            new User() { Id = 2, UserName = "test2" },
            new User() { Id = 3, UserName = "test3" },
        };

        public static Mock<IRepository<User>> GetMock()
        {
            var mock = new Mock<IRepository<User>>();

            mock.Setup(m => m.GetList()).Returns(() => Users);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Users.FirstOrDefault(o => o.Id == id) ?? Users[0]);
            mock.Setup(m => m.Create(It.IsAny<User>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<User>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
