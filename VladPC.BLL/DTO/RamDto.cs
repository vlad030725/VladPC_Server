using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class RamDto : ProductDto
    {
        #region Поля
        public int? Frequency { get; set; }
        public int? CountMemory { get; set; }
        public int? MemoryType { get; set; }
        public int? CountRam { get; set; }
        #endregion

        #region Констукторы
        public RamDto() { }
        public RamDto(Product ram)
        {
            Id = ram.Id;
            Name = ram.Name;
            Category = ram.Category;
            Count = ram.Count;
            Price = ram.Price;
            Frequency = ram.Frequency;
            CountMemory = ram.CountMemory;
            MemoryType = ram.MemoryType;
            CountRam = ram.CountRam;
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
                $"{CountRam} x {CountMemory} Гб; " +
                $"{DictionaryLists.MemoryTypeMap[(MemoryType)MemoryType]}" +
                $"]";
        }
    }
}
