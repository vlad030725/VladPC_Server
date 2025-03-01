using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class ProcessorDto : ProductDto
    {
        #region Поля
        public int? CountCores { get; set; }

        public int? CountStreams { get; set; }

        public int? Frequency { get; set; }

        public int? Socket { get; set; }

        public int? Tdp { get; set; }
        #endregion

        #region Констукторы
        public ProcessorDto() { }

        public ProcessorDto(Product processor)
        {
            Id = processor.Id;
            Name = processor.Name;
            Category = processor.Category;
            Count = processor.Count;
            Price = processor.Price;
            Manufacturer = processor.Manufacturer;
            CountCores = processor.CountCores;
            CountStreams = processor.CountStreams;
            Frequency = processor.Frequency;
            Socket = processor.Socket;
            Tdp = processor.Tdp;
        }
        #endregion

        protected override string CreateCatalogString()
        {
            throw new NotImplementedException();
        }
    }
}
