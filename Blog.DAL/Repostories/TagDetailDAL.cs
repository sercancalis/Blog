using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class TagDetailDAL
    {
        BlogDBContext db;
        public TagDetailDAL()
        {
            db = new BlogDBContext();
        }

        public int Add(TagDetail tagDetail)
        {
            db.Entry(tagDetail).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Delete(TagDetail tagDetail)
        {
            db.Entry(tagDetail).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public int Update(TagDetail tagDetail)
        {
            db.Entry(tagDetail).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public List<TagDetail> GetAll()
        {
            return db.TagDetails.ToList();
        }

        public TagDetail GetByID(int ID)
        {
            return db.TagDetails.Find(ID);
        }
    }
}
