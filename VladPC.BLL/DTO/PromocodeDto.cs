using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class PromocodeDto
    {
        #region Поля
        public int Id { get; set; }

        public string? Code { get; set; }

        public double? Discount { get; set; }
        #endregion

        #region Конструкторы
        public PromocodeDto(Promocode promocode)
        {
            Id = promocode.Id;
            Code = promocode.Code;
            Discount = promocode.Discount;
        }
        public PromocodeDto() { }
        #endregion
    }
}
