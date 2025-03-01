using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.DAL.RepositoryPgs
{
    public class DbReposPgs : IDbRepos
    {
        private VladPcdbContext db;
        private OrderRepositoryPgs OrderRepository;
        private OrderRowRepositoryPgs OrderRowRepository;
        private ProductRepositoryPgs ProductRepository;
        private PromocodeRepositoryPgs PromocodeRepository;
        private UserRepositoryPgs UserRepository;

        public DbReposPgs()
        {
            db = new VladPcdbContext();
        }

        public IRepository<Order> Order
        {
            get
            {
                if (OrderRepository == null)
                    OrderRepository = new OrderRepositoryPgs(db);
                return OrderRepository;
            }
        }

        public IRepository<OrderRow> OrderRow
        {
            get
            {
                if (OrderRowRepository == null)
                    OrderRowRepository = new OrderRowRepositoryPgs(db);
                return OrderRowRepository;
            }
        }

        public IRepository<Product> Product
        {
            get
            {
                if (ProductRepository == null)
                    ProductRepository = new ProductRepositoryPgs(db);
                return ProductRepository;
            }
        }

        public IRepository<Promocode> Promocode
        {
            get
            {
                if (PromocodeRepository == null)
                    PromocodeRepository = new PromocodeRepositoryPgs(db);
                return PromocodeRepository;
            }
        }

        public IRepository<User> User
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepositoryPgs(db);
                return UserRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
