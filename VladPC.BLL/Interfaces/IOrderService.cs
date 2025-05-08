using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
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
        bool AddProductToCart(int idUser, int idProduct);

        /// <summary>
        /// Изменение количества товара в строке заказа
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        bool UpdateOrderRow(ChangeCountOrderRowResponse response);

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
        OrderDto GetCart(int idUser);

        /// <summary>
        /// Возвращает список строк заказа по Id заказа.
        /// </summary>
        /// <param name="idOrder"> Id заказа</param>
        /// <returns>Список строк заказа</returns>
        List<OrderRowDto> GetOrderRows(int idOrder);
        void SetOrder(int idUser);
        List<OrderDto> GetOrderHistory(int idUser);
        bool ApplyPromocode(int idUser, string promocode);
        PromocodeDto? GetPromocode(int? id);
    }
}
