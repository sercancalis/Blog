using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class CommentController
    {
        CommentDAL commentDAL;
        public CommentController()
        {
            commentDAL = new CommentDAL();
        }

        public List<Comment> GetAllActiveComments()
        {
            return commentDAL.GetAll();
        }

        public bool DeleteComment(int ID)
        {
            return commentDAL.Delete(commentDAL.GetByID(ID)) > 0;
        }

        public List<Comment> GetAllInActiveComments()
        {
            return commentDAL.GetAll().Where(x => x.IsActive == false).ToList();
        }

        public bool AcceptComment(int ID)
        {
            Comment comment = commentDAL.GetByID(ID);
            comment.IsActive = true;
            return commentDAL.Update(comment) > 0;
        }
    }
}
