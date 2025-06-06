using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.Common;
using VladPC.DAL.Models;

namespace VladPC.BLL.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        /// <param name="idUser">Id пользователя</param>
        /// <param name="idProduct">Id товара</param>
        /// <returns>Успешно ли товар добавлен в корзину</returns>
        bool AddProductToOrder(int idUser, int idProduct, Status status);

        /// <summary>
        /// Изменение количества товара в строке заказа
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        bool UpdateCountOrderRow(ChangeCountOrderRowResponse response);

        /// <summary>
        /// Удаление строки заказа по Id
        /// </summary>
        /// <param name="id">Id строки заказа</param>
        void DeleteOrderRow(int id);

        /// <summary>
        /// Возвращает корзину пользователя по его Id
        /// </summary>
        /// <param name="idUser">Id пользователя</param>
        /// <returns>Корзина пользователя</returns>
        OrderDto GetCart(int idUser, Status status);

        /// <summary>
        /// Возвращает список строк заказа по Id заказа.
        /// </summary>
        /// <param name="idOrder"> Id заказа</param>
        /// <returns>Список строк заказа</returns>
        List<OrderRowDto> GetOrderRows(int idOrder);
        bool SetOrder(int idUser);
        List<OrderDto> GetOrderHistory(int idUser);
        bool ApplyPromocode(int idUser, string promocode);
        PromocodeDto? GetPromocode(int? id);
        void UpdateOrderRow(int id, int idProduct);
        void CreateOrderRow(OrderRowDto orderRow);
        bool AddConfigurationToCart(int idUser);
        void CleanOrder(int idUser, Status status);
        List<OrderDto> GetUserOrders();
        bool CompliteOrder(int id);
    }
}
