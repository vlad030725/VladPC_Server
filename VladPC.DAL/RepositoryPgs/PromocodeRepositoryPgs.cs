using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.DAL.RepositoryPgs
{
    public class PromocodeRepositoryPgs : IRepository<Promocode>
    {
        private VladPcdbContext db;

        public PromocodeRepositoryPgs(VladPcdbContext db)
        {
            this.db = db;
        }

        public void Create(Promocode item)
        {
            db.Promocodes.Add(item);
        }

        public void Delete(int id)
        {
            Promocode? item = db.Promocodes.Find(id);
            if (item != null)
            {
                db.Promocodes.Remove(item);
            }
        }

        public Promocode? GetItem(int id)
        {
            return db.Promocodes.Find(id);
        }

        public List<Promocode> GetList()
        {
            return db.Promocodes.ToList();
        }

        public void Update(Promocode item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
