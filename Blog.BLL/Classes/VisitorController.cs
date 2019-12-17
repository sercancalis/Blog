using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class VisitorController
    {
        VisitorDAL visitorDAL;
        public VisitorController()
        {
            visitorDAL = new VisitorDAL();
        }

        public bool AddVisitor()
        {
            return visitorDAL.AddVisitor(new Visitor() { VisitedDate = DateTime.Now }) > 0;
        }
        public int GetVisitorsToDay()
        {
            return visitorDAL.Visitors().Count(x => (DateTime.Now-x.VisitedDate).Days < 1);
        }
        public int GetVisitorsToWeek()
        {
            return visitorDAL.Visitors().Count(x => (DateTime.Now - x.VisitedDate).Days < 8);
        }
        public int GetVisitorsToMonth()
        {
            return visitorDAL.Visitors().Count(x => (DateTime.Now - x.VisitedDate).Days < 32);
        }
        public int GetAllVisitors()
        {
            return visitorDAL.Visitors().Count();
        }
    }
}
