using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.Common;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IDbRepos db;
        private IProductService _productService;

        public OrderService(IDbRepos db, IProductService productService)
        {
            this.db = db;
            _productService = productService;
        }



        #region Order
        public bool AddProductToCart(int idUser, int idProduct)
        {
            var cart = GetCart(idUser);
            var product = _productService.GetProduct(idProduct);
            if (product == null || product.Count == 0)
                return false;
            OrderRow? row = db.OrderRow.GetList().FirstOrDefault(i => i.OrderId == cart.Id && i.ProductId == idProduct);
            if (row != null)
                return false;
            db.OrderRow.Create(new OrderRow()
            {
                OrderId = cart.Id,
                ProductId = idProduct,
                Price = product.Price,
                Count = 1
            });
            Save();
            return true;
        }
        
        public OrderDto GetCart(int idUser)
        {
            Order? order;
            try
            {
                order = db.Order.GetList().Where(i => i.Status == (int)Status.InCart && i.UserId == idUser).Single();
            }
            catch(Exception ex)
            {
                db.Order.Create(new Order()
                {
                    UserId = idUser,
                    PromocodeId = null,
                    Status = (int)Status.InCart,
                    CreationDate = null,
                });
                Save();
                order = db.Order.GetList().Where(i => i.Status == (int)Status.InCart && i.UserId == idUser).SingleOrDefault();
            }
            var orderRows = db.OrderRow.GetList().Where(i => i.OrderId == order.Id).ToList();
            return new OrderDto(order, GetOrderRows(order.Id), GetPromocode(order.PromocodeId));
        }

        public void SetOrder(int idUser)
        {
            var cart = GetCart(idUser);
            Order order = db.Order.GetItem(cart.Id);
            order.Status = (int)Status.OnTheWay;
            order.CreationDate = DateTime.UtcNow;
            Save();
        }

        public List<OrderDto> GetOrderHistory(int idUser)
        {
            return db.Order.GetList()
                .Where(i => i.UserId == idUser && i.Status != (int)Status.InCart && i.Status != (int)Status.InConfigurator)
                .Select(i => new OrderDto(i, GetOrderRows(i.Id), GetPromocode(i.PromocodeId)))
                .ToList();
        }

        public bool ApplyPromocode(int idUser, string promocode)
        {
            var pc = db.Promocode.GetList().FirstOrDefault(i => i.Code == promocode);
            if (pc != null)
            {
                var cart = GetCart(idUser);
                Order order = db.Order.GetItem(cart.Id);
                order.Promocode = pc;
                Save();
                return true;
            }
            return false;
        }
        #endregion



        #region OrderRow
        public List<OrderRowDto> GetOrderRows(int idOrder)
        {
            return db.OrderRow.GetList().Where(i => i.OrderId == idOrder).Select(i => new OrderRowDto(i, _productService.GetProduct((int)i.ProductId))).ToList();
        }

        public void DeleteOrderRow(int id)
        {
            db.OrderRow.Delete(id);
            Save();
        }

        public bool UpdateOrderRow(ChangeCountOrderRowResponse response)
        {
            OrderRow orderRow = db.OrderRow.GetItem(response.Id);
            ProductDto product = _productService.GetProduct((int)orderRow.ProductId);
            if (orderRow.Count - 1 >= 1 && !response.IsPlus || orderRow.Count + 1 <= product.Count && response.IsPlus)
            {
                orderRow.Count += response.IsPlus ? 1 : -1;
                Save();
                return true;
            }
            return false;
        }
        #endregion

        public PromocodeDto? GetPromocode(int? id)
        {
            if (id == null)
                return null;
            return new PromocodeDto(db.Promocode.GetItem((int)id));
        }



        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
