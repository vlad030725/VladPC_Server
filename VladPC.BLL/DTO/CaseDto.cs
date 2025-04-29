using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class CaseDto : ProductDto
    {
        #region Поля
        public int? HeightCooler { get; set; }
        public int? FormFactor { get; set; }
        #endregion

        #region Констукторы
        public CaseDto() { }
        public CaseDto(Product casePc)
        {
            Id = casePc.Id;
            Name = casePc.Name;
            Category = casePc.Category;
            Count = casePc.Count;
            Price = casePc.Price;
            HeightCooler = casePc.HeightCooler;
            FormFactor = casePc.FormFactor;
            CatalogString = CreateCatalogString();
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"Максимальная высота кулера = {HeightCooler} мм; " +
                $"{DictionaryLists.FormFactorMap[(FormFactor)FormFactor]}" +
                $"]";
        }
    }
}
