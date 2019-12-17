using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class InfoDAL
    {
        BlogDBContext db;
        public InfoDAL()
        {
            db = new BlogDBContext();
        }

        public int Add(Info info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Info info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public List<Info> GetAll()
        {
            return db.Infos.ToList();
        }

        public Info Get()
        {
            return db.Infos.FirstOrDefault();
        }
    }
}
