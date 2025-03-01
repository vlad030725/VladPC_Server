using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;

namespace VladPC.DAL.RepositoryPgs
{
    public class UserRepositoryPgs : IRepository<User>
    {
        private VladPcdbContext db;

        public UserRepositoryPgs(VladPcdbContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User? item = db.Users.Find(id);
            if (item != null)
            {
                db.Users.Remove(item);
            }
        }

        public User? GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetList()
        {
            return db.Users.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
