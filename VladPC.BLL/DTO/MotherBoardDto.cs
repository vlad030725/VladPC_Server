using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class MotherBoardDto : ProductDto
    {
        #region Поля
        public int? Socket { get; set; }
        public int? MemoryType { get; set; }
        public int? Chipset { get; set; }
        public int? CountRam { get; set; }
        public int? CountSsdm2 { get; set; }
        public int? FormFactor { get; set; }
        #endregion

        #region Констукторы
        public MotherBoardDto() { }
        public MotherBoardDto(Product motherBoard)
        {
            Id = motherBoard.Id;
            Name = motherBoard.Name;
            Category = motherBoard.Category;
            Count = motherBoard.Count;
            Price = motherBoard.Price;
            Manufacturer = motherBoard.Manufacturer;
            Socket = motherBoard.Socket;
            MemoryType = motherBoard.MemoryType;
            Chipset = motherBoard.Chipset;
            CountRam = motherBoard.CountRam;
            CountSsdm2 = motherBoard.CountSsdm2;
            FormFactor = motherBoard.FormFactor;
        }
        #endregion

        protected override string CreateCatalogString()
        {
            return $"{DictionaryLists.CategoryMap[(Category)Category]} " +
                $"{DictionaryLists.CompanyMap[(Company)Manufacturer]} " +
                $"{Name} " +
                $"[" +
                $"{DictionaryLists.SocketMap[(Socket)Socket]}; " +
                $"{DictionaryLists.ChipsetMap[(Chipset)Chipset]}; " +
                $"{DictionaryLists.MemoryTypeMap[(MemoryType)MemoryType]} x {CountRam}; " +
                $"{CountSsdm2} x M.2; " +
                $"{DictionaryLists.FormFactorMap[(FormFactor)FormFactor]}; " +
                $"]";
        }
    }
}
