using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class PowerSupplyDto : ProductDto
    {
        #region Поля
        public int? Power { get; set; }
        public int? Status80plus { get; set; }
        public int? FormFactor { get; set; }
        #endregion

        #region Констукторы
        public PowerSupplyDto() { }
        public PowerSupplyDto(Product powerSupply)
        {
            Id = powerSupply.Id;
            Name = powerSupply.Name;
            Category = powerSupply.Category;
            Count = powerSupply.Count;
            Price = powerSupply.Price;
            Manufacturer = powerSupply.Manufacturer;
            Power = powerSupply.Power;
            Status80plus = powerSupply.Status80plus;
            FormFactor = powerSupply.FormFactor;
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"{Power} Вт; " +
                $"80+ {DictionaryLists.Status80plusMap[(Status80plus)Status80plus]}; " +
                $"{DictionaryLists.FormFactorMap[(FormFactor)FormFactor]}" +
                $"]";
        }
    }
}
