using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class InfoController
    {
        InfoDAL InfoDAL;
        public InfoController()
        {
            InfoDAL = new InfoDAL();
        }

        public Info GetInfo()
        {
            return InfoDAL.Get();
        }

        public bool UpdateInfo(Info info)
        {
            if (InfoDAL.Get() == null)
                return InfoDAL.Add(info) > 0;
            return InfoDAL.Update(info) > 0;
        }
    }
}
