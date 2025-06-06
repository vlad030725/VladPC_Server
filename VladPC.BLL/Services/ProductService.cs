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

        public IEnumerable<ProductDto> GetProducts(Filter filter, int mode, int idUser, OrderDto? order)
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
            if (mode == (int)Status.InConfigurator)
            {
                products = [.. CheckCompatibility(filter, products, idUser, order)];
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

        public List<ProductDto> CheckCompatibility(Filter filter, List<ProductDto> products, int idUser, OrderDto order)
        {
            ProcessorDto? SelectedCpu = null;
            MotherBoardDto? SelectedMotherboard = null;
            PowerSupplyDto? SelectedPowerSupply = null;
            CaseDto? SelectedCase = null;
            GraphicsCardDto? SelectedGpu = null;
            CoolerDto? SelectedCooler = null;
            RamDto? SelectedRam = null;
            SsdDto? SelectedSsd = null;

            foreach (var row in order.OrderRows)
            {
                switch (row.Product.Category)
                {
                    case 0: SelectedCpu = row.Product as ProcessorDto; break;
                    case 1: SelectedMotherboard = row.Product as MotherBoardDto; break;
                    case 2: SelectedPowerSupply = row.Product as PowerSupplyDto; break;
                    case 3: SelectedCase = row.Product as CaseDto; break;
                    case 4: SelectedGpu = row.Product as GraphicsCardDto; break;
                    case 5: SelectedCooler = row.Product as CoolerDto; break;
                    case 6: SelectedRam = row.Product as RamDto; break;
                    case 7: SelectedSsd = row.Product as SsdDto; break;
                }
            }

            switch (filter.IdCategory)
            {
                case Category.Processor:
                    products = [.. products
                        .Where(i => (SelectedMotherboard == null || SelectedMotherboard.Socket == (i as ProcessorDto).Socket) &&
                                    (SelectedCooler == null || SelectedCooler.Socket == (i as ProcessorDto).Socket && SelectedCooler.Tdp >= (i as ProcessorDto).Tdp))]
                        ;
                    break;
                case Category.MotherBoard:
                    products = [.. products
                        .Where(i => (SelectedCpu == null || SelectedCpu.Socket == (i as MotherBoardDto).Socket) &&
                                    (SelectedCase == null || SelectedCase.FormFactor == (i as MotherBoardDto).FormFactor) &&
                                    (SelectedCooler == null || SelectedCooler.Socket == (i as MotherBoardDto).Socket) &&
                                    (SelectedRam == null || SelectedRam.CountRam <= (i as MotherBoardDto).CountRam && SelectedRam.MemoryType == (i as MotherBoardDto).MemoryType) &&
                                    (SelectedSsd == null || (i as MotherBoardDto).CountRam > 0))]
                        ;
                    break;
                case Category.PowerSupply:
                    products = [.. products
                        .Where(i => (SelectedGpu == null || SelectedGpu.Power <= (i as PowerSupplyDto).Power))]
                        ;
                    break;
                case Category.Case:
                    products = [.. products
                        .Where(i => (SelectedMotherboard == null || SelectedMotherboard.FormFactor == (i as CaseDto).FormFactor) &&
                                    (SelectedCooler == null || SelectedCooler.HeightCooler == (i as CaseDto).HeightCooler))]
                        ;
                    break;
                case Category.GraphicsCard:
                    products = [.. products
                        .Where(i => (SelectedPowerSupply == null || SelectedPowerSupply.Power >= (i as GraphicsCardDto).Power))]
                        ;
                    break;
                case Category.Cooler:
                    products = [.. products
                        .Where(i => (SelectedCpu == null || SelectedCpu.Tdp <= (i as CoolerDto).Tdp) &&
                                    (SelectedCase == null || SelectedCase.HeightCooler >= (i as CoolerDto).HeightCooler))]
                        ;
                    break;
                case Category.RAM:
                    products = [.. products
                        .Where(i => (SelectedMotherboard == null || SelectedMotherboard.CountRam >= (i as RamDto).CountRam && SelectedMotherboard.MemoryType == (i as RamDto).MemoryType))]
                        ;
                    break;
                case Category.SSD:
                    products = [.. products
                        .Where(i => (SelectedMotherboard == null || SelectedMotherboard.CountSsdm2 > 0))]
                        ;
                    break;
                default:
                    break;
            }

            return products;
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
