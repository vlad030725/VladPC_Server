using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class SsdDto : ProductDto
    {
        #region Поля
        public int? CountMemory { get; set; }
        #endregion

        #region Констукторы
        public SsdDto() { }
        public SsdDto(Product ssd)
        {
            Id = ssd.Id;
            Name = ssd.Name;
            Category = ssd.Category;
            Count = ssd.Count;
            Price = ssd.Price;
            CountMemory = ssd.CountMemory;
            CatalogString = CreateCatalogString();
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"{CountMemory} Гб" +
                $"]";
        }
    }
}
