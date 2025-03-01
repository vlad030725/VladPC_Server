using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class MotherBoardDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Category { get; set; }

        public int? Count { get; set; }

        public int? Price { get; set; }

        public int? Manufacturer { get; set; }

        public int? Socket { get; set; }

        public int? MemoryType { get; set; }

        public int? Chipset { get; set; }

        public int? CountRam { get; set; }

        public int? CountSsdm2 { get; set; }

        public int? FormFactor { get; set; }

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
    }
}
