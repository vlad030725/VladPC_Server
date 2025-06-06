using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.Common;

namespace VladPC.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<CategoryDto> GetCategoryDictionary();
        CategoryDto GetCategory(int id);
        IEnumerable<ProductDto> GetProducts(Filter filter, int mode, int idUser = -1, OrderDto? order = null);
        ProductDto? GetProduct(int id);
        List<ProductDto> CheckCompatibility(Filter filter, List<ProductDto> products, int idUser, OrderDto order);
    }
}
