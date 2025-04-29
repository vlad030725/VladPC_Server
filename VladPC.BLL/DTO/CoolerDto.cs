using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class CoolerDto : ProductDto
    {
        #region Поля
        public int? Socket { get; set; }
        public int? HeightCooler { get; set; }
        public int? Tdp { get; set; }
        #endregion

        #region Констукторы
        public CoolerDto() { }
        public CoolerDto(Product cooler)
        {
            Id = cooler.Id;
            Name = cooler.Name;
            Category = cooler.Category;
            Count = cooler.Count;
            Price = cooler.Price;
            Socket = cooler.Socket;
            HeightCooler = cooler.HeightCooler;
            Tdp = cooler.Tdp;
            CatalogString = CreateCatalogString();
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"{HeightCooler} мм; " +
                $"{Tdp} Вт; " +
                $"{DictionaryLists.SocketMap[(Socket)Socket]}" +
                $"]";
        }
    }
}
