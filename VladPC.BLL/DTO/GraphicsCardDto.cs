using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class GraphicsCardDto : ProductDto
    {
        #region Поля
        public int? Frequency { get; set; }
        public int? CountMemory { get; set; }
        public int? MemoryType { get; set; }
        public int? Power { get; set; }
        #endregion

        #region Констукторы
        public GraphicsCardDto() { }
        public GraphicsCardDto(Product graphicsCard)
        {
            Id = graphicsCard.Id;
            Name = graphicsCard.Name;
            Category = graphicsCard.Category;
            Count = graphicsCard.Count;
            Price = graphicsCard.Price;
            Frequency = graphicsCard.Frequency;
            CountMemory = graphicsCard.CountMemory;
            MemoryType = graphicsCard.MemoryType;
            Power = graphicsCard.Power;
            CatalogString = CreateCatalogString();
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"{Frequency} МГц; " +
                $"{DictionaryLists.MemoryTypeMap[(MemoryType)MemoryType]}; " +
                $"{CountMemory}" +
                $"Рекомендуемы БП {Power}" +
                $"]";
        }
    }
}
