using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class TagController
    {
        TagDAL tagDAL;
        public TagController()
        {
            tagDAL = new TagDAL();
        }

        public List<Tag> GetTags()
        {
            return tagDAL.GetAll();
        }

        public bool DeleteTag(int ID)
        {
            return tagDAL.Delete(tagDAL.GetByID(ID)) > 0;
        }

        public bool AddTag(string Name)
        {
            return tagDAL.Add(new Tag() { Name = Name }) > 0;
        }
    }
}
