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
        public bool AddProductToOrder(int idUser, int idProduct, Status status)
        {
            var order = GetCart(idUser, status);
            var product = _productService.GetProduct(idProduct);
            if (product == null || product.Count == 0)
                return false;
            var row = GetOrderRows(order.Id).FirstOrDefault(i => i.OrderId == order.Id && (i.ProductId == idProduct && status == Status.InCart || i.Product.Category == product.Category && status == Status.InConfigurator));
            if (row != null && status == Status.InCart)
                return false;
            else if (row != null && status == Status.InConfigurator)
                DeleteOrderRow(row.Id);
            db.OrderRow.Create(new OrderRow()
            {
                OrderId = order.Id,
                ProductId = idProduct,
                Price = product.Price,
                Count = 1
            });
            Save();
            return true;
        }
        
        public OrderDto GetCart(int idUser, Status status)
        {
            Order? order;
            try
            {
                order = db.Order.GetList().Where(i => i.Status == (int)status && i.UserId == idUser).Single();
            }
            catch(Exception ex)
            {
                db.Order.Create(new Order()
                {
                    UserId = idUser,
                    PromocodeId = null,
                    Status = (int)status,
                    CreationDate = null,
                });
                Save();
                order = db.Order.GetList().Where(i => i.Status == (int)status && i.UserId == idUser).SingleOrDefault();
            }
            var orderRows = db.OrderRow.GetList().Where(i => i.OrderId == order.Id).ToList();
            return new OrderDto(order, GetOrderRows(order.Id), GetPromocode(order.PromocodeId));
        }

        public bool SetOrder(int idUser)
        {
            var cart = GetCart(idUser, Status.InCart);
            if (cart.OrderRows.Count == 0)
                return false;
            Order order = db.Order.GetItem(cart.Id);
            order.Status = (int)Status.OnTheWay;
            order.CreationDate = DateTime.UtcNow;
            Save();
            return true;
        }

        public bool CompliteOrder(int id)
        {
            Order order = db.Order.GetItem(id);
            order.Status = (int)Status.Completed;
            Save();
            return true;
        }

        public List<OrderDto> GetOrderHistory(int idUser)
        {
            return db.Order.GetList()
                .Where(i => i.UserId == idUser && i.Status != (int)Status.InCart && i.Status != (int)Status.InConfigurator)
                .Select(i => new OrderDto(i, GetOrderRows(i.Id), GetPromocode(i.PromocodeId)))
                .ToList();
        }

        public List<OrderDto> GetUserOrders()
        {
            return db.Order.GetList()
                .Where(i => i.Status == (int)Status.OnTheWay)
                .Select(i => new OrderDto(i, GetOrderRows(i.Id), GetPromocode(i.PromocodeId)))
                .ToList();
        }

        public bool ApplyPromocode(int idUser, string promocode)
        {
            var pc = db.Promocode.GetList().FirstOrDefault(i => i.Code == promocode);
            if (pc != null)
            {
                var cart = GetCart(idUser, Status.InCart);
                Order order = db.Order.GetItem(cart.Id);
                order.Promocode = pc;
                Save();
                return true;
            }
            return false;
        }

        public bool AddConfigurationToCart(int idUser)
        {
            var config = GetCart(idUser, Status.InConfigurator);
            List<bool> inConfig = new List<bool>() { false, false, false, false, false, false, false, false };
            config.OrderRows.ForEach(i => inConfig[(int)i.Product.Category] = true);
            if (inConfig.Contains(false))
                return false;
            CleanOrder(idUser, Status.InCart);
            var cart = GetCart(idUser, Status.InCart);

            var configRows = GetOrderRows(config.Id);
            for (int i = 0; i < configRows.Count; i++)
            {
                configRows[i].OrderId = cart.Id;
                CreateOrderRow(configRows[i]);
            }
            Save();

            return true;
        }

        public void CleanOrder(int idUser, Status status)
        {
            var order = GetCart(idUser, status);
            order.OrderRows.ForEach(i => db.OrderRow.Delete(i.Id));
            Save();
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

        public bool UpdateCountOrderRow(ChangeCountOrderRowResponse response)
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

        public void UpdateOrderRow(int id, int idProduct)
        {
            OrderRow orderRow = db.OrderRow.GetItem(id);
            orderRow.ProductId = idProduct;
            Save();
        }

        public void CreateOrderRow(OrderRowDto orderRow)
        {
            db.OrderRow.Create(new OrderRow()
            {
                OrderId = orderRow.OrderId,
                ProductId = orderRow.ProductId,
                Price = orderRow.Price,
                Count = orderRow.Count,
            });
            Save();
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
