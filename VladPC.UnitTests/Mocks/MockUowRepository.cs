using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;

namespace VladPC.UnitTests.Mocks
{
    public static class MockUowRepository
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
            var ProductRepoMock = MockProductRepository.GetMock();
            var UserRepoMock = MockUserRepository.GetMock();
            var OrderRowRepoMock = MockOrderRowRepository.GetMock();
            var OrderRepoMock = MockOrderRepository.GetMock();
            var PromocodeRepoMock = MockPromocodeRepository.GetMock();

            mock.Setup(m => m.Product).Returns(() => ProductRepoMock.Object);
            mock.Setup(m => m.User).Returns(() => UserRepoMock.Object);
            mock.Setup(m => m.OrderRow).Returns(() => OrderRowRepoMock.Object);
            mock.Setup(m => m.Order).Returns(() => OrderRepoMock.Object);
            mock.Setup(m => m.Promocode).Returns(() => PromocodeRepoMock.Object);
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
