using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.Common;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.BLL.Services
{
    public class ProductService : IProductService
    {
        private IDbRepos db;

        public ProductService(IDbRepos db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryDto> GetCategoryDictionary()
        {
            return DictionaryLists.CategoryMap.Select(i => new CategoryDto(i.Key, i.Value)).ToList();
        }

        public CategoryDto GetCategory(int id)
        {
            return new CategoryDto((Category)id, DictionaryLists.CategoryMap[(Category)id]);
        }

        public IEnumerable<ProductDto> GetProducts(Filter filter)
        {
            List<ProductDto> products = new List<ProductDto>();
            switch (filter.IdCategory)
            {
                case Category.Processor:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.Processor).Select(i => new ProcessorDto(i)).ToList()];
                    break;
                case Category.MotherBoard:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.MotherBoard).Select(i => new MotherBoardDto(i)).ToList()];
                    break;
                case Category.PowerSupply:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.PowerSupply).Select(i => new PowerSupplyDto(i)).ToList()];
                    break;
                case Category.Case:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.Case).Select(i => new CaseDto(i)).ToList()];
                    break;
                case Category.GraphicsCard:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.GraphicsCard).Select(i => new GraphicsCardDto(i)).ToList()];
                    break;
                case Category.Cooler:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.Cooler).Select(i => new CoolerDto(i)).ToList()];
                    break;
                case Category.RAM:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.RAM).Select(i => new RamDto(i)).ToList()];
                    break;
                case Category.SSD:
                    products = [.. db.Product.GetList().Where(i => i.Category == (int)Category.SSD).Select(i => new SsdDto(i)).ToList()];
                    break;
                default:
                    return Enumerable.Empty<ProductDto>();

            }
            return products.Where(i => i.Price > filter.MinPrice && i.Price < filter.MaxPrice);
        }

        public ProductDto? GetProduct(int id)
        {
            Product? product = db.Product.GetItem(id);

            if (product == null)
                return null;

            switch ((Category)product.Category)
            {
                case Category.Processor:
                    return new ProcessorDto(product);
                case Category.MotherBoard:
                    return new MotherBoardDto(product);
                case Category.PowerSupply:
                    return new PowerSupplyDto(product);
                case Category.Case:
                    return new CaseDto(product);
                case Category.GraphicsCard:
                    return new GraphicsCardDto(product);
                case Category.Cooler:
                    return new CoolerDto(product);
                case Category.RAM:
                    return new RamDto(product);
                case Category.SSD:
                    return new SsdDto(product);
                default:
                    return null;

            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
