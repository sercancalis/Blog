using Blog.DAL.Classes;
using Blog.UI.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Blog.UI.Controllers.Admin
{
    [SessionController]
    public class AdminController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ProjectCount = new BLL.Classes.ProjectController().GetAllProjects().Count(x=>x.TagDetails.Any(y=>y.Tag.Name.Contains("Proje")));
            ViewBag.BlogCount = new BLL.Classes.ProjectController().GetAllProjects().Count(x=>x.TagDetails.Any(y=>y.Tag.Name.Contains("Blog")));
            ViewBag.CommentCount = new BLL.Classes.CommentController().GetAllActiveComments().Count;
            ViewBag.Visitors = new BLL.Classes.VisitorController().GetAllVisitors();
            ViewBag.DailyVisitors = new BLL.Classes.VisitorController().GetVisitorsToDay();
            ViewBag.WeeklyVisitors = new BLL.Classes.VisitorController().GetVisitorsToWeek();
            ViewBag.MonthlyVisitors = new BLL.Classes.VisitorController().GetVisitorsToMonth();
            return View();
        }
        [Route(Name ="Projects")]
        public ActionResult Projects()
        {
            return View(new BLL.Classes.ProjectController().GetAllProjects());
        }

        [HttpPost]
        public ActionResult DeleteProject(int ID)
        {
            if (!new BLL.Classes.ProjectController().DeleteProject(ID))
                return HttpNotFound();
            return RedirectToAction("Projects");
        }
        [Route(Name = "AddProject")]
        public ActionResult AddProject()
        {
            ViewBag.tags = new BLL.Classes.TagController().GetTags();
            return View();
        }
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddProject(Project project, HttpPostedFileBase File, int[] tags)
        {
            if (!new BLL.Classes.ProjectController().AddProject(project, new WebImage(File.InputStream).GetBytes(), tags))
                return HttpNotFound();
            return RedirectToAction("Projects");
        }
        [Route(Name = "UpdateProject")]
        public ActionResult UpdateProject(int ID)
        {
            ViewBag.tags = new BLL.Classes.TagController().GetTags();
            return View(new BLL.Classes.ProjectController().GetProject(ID));
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProject(Project project, HttpPostedFileBase File, int[] tags)
        {
            if (File != null)
                project.Image = new WebImage(File.InputStream).GetBytes();

            if (!new BLL.Classes.ProjectController().UpdateProject(project, tags))
                return HttpNotFound();
            return RedirectToAction("Projects");
        }
        [Route(Name = "Tags")]
        public ActionResult Tags()
        {
            return View(new BLL.Classes.TagController().GetTags());
        }

        [HttpPost]
        public ActionResult DeleteTag(int ID)
        {
            if (!new BLL.Classes.TagController().DeleteTag(ID))
                return HttpNotFound();
            return RedirectToAction("Tags");
        }

        [HttpPost]
        public ActionResult AddTag(string name)
        {
            if (!new BLL.Classes.TagController().AddTag(name))
                return HttpNotFound();
            return RedirectToAction("Tags");
        }
        [Route(Name = "Comments")]
        public ActionResult Comments()
        {
            return View(new BLL.Classes.CommentController().GetAllActiveComments());
        }
        [HttpPost]
        public ActionResult DeleteComment(int ID)
        {
            if (!new BLL.Classes.CommentController().DeleteComment(ID))
                return HttpNotFound();
            return RedirectToAction("Comments");
        }
        [Route(Name = "InActiveComments")]
        public ActionResult InActiveComments()
        {
            return View(new BLL.Classes.CommentController().GetAllInActiveComments());
        }

        [HttpPost]
        public ActionResult AcceptComment(int ID)
        {
            if (!new BLL.Classes.CommentController().AcceptComment(ID))
                return HttpNotFound();
            return RedirectToAction("InActiveComments");
        }

        [Route(Name = "Info")]
        public ActionResult Info()
        {
            return View(new BLL.Classes.InfoController().GetInfo());
        }
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateInfo(Info info)
        {
            if (!new BLL.Classes.InfoController().UpdateInfo(info))
                return HttpNotFound();
            return RedirectToAction("Info");
        }
    }
}