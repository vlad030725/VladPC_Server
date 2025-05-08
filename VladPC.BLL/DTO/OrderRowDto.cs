using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class OrderRowDto
    {
        #region Поля
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Price { get; set; }

        public int? Count { get; set; }

        public ProductDto? Product { get; set; }
        #endregion

        #region Конструкторы
        public OrderRowDto(OrderRow orderRow, ProductDto? product)
        {
            Id = orderRow.Id;
            OrderId = orderRow.OrderId;
            ProductId = orderRow.ProductId;
            Price = orderRow.Price;
            Count = orderRow.Count;
            Product = product;
        }
        public OrderRowDto() { }
        #endregion
    }
}
