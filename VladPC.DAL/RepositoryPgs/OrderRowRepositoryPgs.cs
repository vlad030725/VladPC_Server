using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.DAL.RepositoryPgs
{
    public class OrderRowRepositoryPgs : IRepository<OrderRow>
    {
        private VladPcdbContext db;

        public OrderRowRepositoryPgs(VladPcdbContext db)
        {
            this.db = db;
        }

        public void Create(OrderRow item)
        {
            db.OrderRows.Add(item);
        }

        public void Delete(int id)
        {
            OrderRow? item = db.OrderRows.Find(id);
            if (item != null)
            {
                db.OrderRows.Remove(item);
            }
        }

        public OrderRow? GetItem(int id)
        {
            return db.OrderRows.Find(id);
        }

        public List<OrderRow> GetList()
        {
            return db.OrderRows.ToList();
        }

        public void Update(OrderRow item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
