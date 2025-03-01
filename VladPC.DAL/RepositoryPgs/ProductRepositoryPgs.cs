using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.DAL.RepositoryPgs
{
    public class ProductRepositoryPgs : IRepository<Product>
    {
        private VladPcdbContext db;

        public ProductRepositoryPgs(VladPcdbContext db)
        {
            this.db = db;
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product? item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
            }
        }

        public Product? GetItem(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetList()
        {
            return db.Products.ToList();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
