using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class VisitorDAL
    {
        BlogDBContext db;
        public VisitorDAL()
        {
            db = new BlogDBContext();
        }

        public List<Visitor> Visitors()
        {
            return db.Visitors.ToList();
        }

        public int AddVisitor(Visitor visitor)
        {
            db.Entry(visitor).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
    }
}
