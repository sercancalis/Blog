using Blog.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Projects = new BLL.Classes.ProjectController().GetAllProjects().Where(x=>x.TagDetails.Any(y=>y.Tag.Name.Contains("Proje"))).ToList();
            ViewBag.Tags = new BLL.Classes.TagController().GetTags().Where(x=>x.TagDetails.Count > 0);
            return View(new BLL.Classes.InfoController().GetInfo());
        }

        public PartialViewResult ProjectDetails(int ID)
        {
            return PartialView(new BLL.Classes.ProjectController().GetProject(ID));
        }
    }
}