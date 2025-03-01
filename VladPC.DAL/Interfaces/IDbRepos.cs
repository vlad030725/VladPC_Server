using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Order> Order { get; }
        IRepository<OrderRow> OrderRow { get; }
        IRepository<Product> Product { get; }
        IRepository<Promocode> Promocode { get; }
        IRepository<User> User { get; }
        int Save();
    }
}
