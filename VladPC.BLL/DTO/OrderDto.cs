using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class OrderDto
    {
        #region Поля
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? PromocodeId { get; set; }

        public int? Status { get; set; }

        public DateTime? CreationDate { get; set; }

        public List<OrderRowDto>? OrderRows { get; set; }

        public PromocodeDto? Promocode { get; set; }
        #endregion

        #region Конструкторы
        public OrderDto(Order order, List<OrderRowDto>? orderRows, PromocodeDto? promocode)
        {
            Id = order.Id;
            UserId = order.UserId;
            PromocodeId = order.PromocodeId;
            Status = order.Status;
            CreationDate = order.CreationDate;
            OrderRows = orderRows;
            Promocode = promocode;
        }
        public OrderDto() { }
        #endregion
    }
}
