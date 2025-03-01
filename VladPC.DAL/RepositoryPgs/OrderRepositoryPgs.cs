using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;
using VladPC.DAL;

namespace VladPC.DAL.RepositoryPgs
{
    public class OrderRepositoryPgs : IRepository<Order>
    {
        private VladPcdbContext db;

        public OrderRepositoryPgs(VladPcdbContext db)
        {
            this.db = db;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order? item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Remove(item);
            }
        }

        public Order? GetItem(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> GetList()
        {
            return db.Orders.ToList();
        }

        public void Update(Order item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
