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
    public class ProductServiceTest
    {
        Mock<IDbRepos> uowMock;
        IProductService productService;

        public ProductServiceTest()
        {
            uowMock = MockUowRepository.GetMock();
            productService = new ProductService(uowMock.Object);
        }

        [Fact]
        public void GetCategoryDictionary_Success()
        {
            var categories = productService.GetCategoryDictionary();
            Assert.Equal(categories.Count(), 8);
        }

        [Fact]
        public void GetCategory_Success()
        {
            var category = productService.GetCategory(0);
            Assert.Equal(category.Name, "Процессор");
        }

        [Fact]
        public void GetProducts_Success()
        {
            var products = productService.GetProducts(new BLL.DTO.Filter { IdCategory = 0 }, 0, 1);
            Assert.Equal(products.Count(), 9);
        }

        [Fact]
        public void GetProduct_Success()
        {
            var product = productService.GetProduct(1);
            Assert.Equal(product.Id, 1);
        }
    }
}
