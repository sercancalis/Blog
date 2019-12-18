using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.UI.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        [Route(Name = "Security")]
        public ActionResult Index()
        {
            ViewBag.email = GetCookie("email");
            ViewBag.password = GetCookie("password");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(string email, string password, bool rememberme)
        {
            if (email == "” && password == "")
            {
                if (rememberme)
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    CreateCookie("email", email);
                    CreateCookie("password", password);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    DeleteCookie("email");
                    DeleteCookie("password");
                }
                Session.Add("email", "sercancalis7@gmail.com");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private void CreateCookie(string name, string value)
        {
            HttpCookie cookieVisitor = new HttpCookie(name, value);
            Response.Cookies.Add(cookieVisitor);
            Response.Cookies[name].Expires = DateTime.Now.AddMonths(1);
        }

        private string GetCookie(string name)
        {
            if (Request.Cookies.AllKeys.Contains(name))
            {
                return Request.Cookies[name].Value;
            }
            return null;
        }
        private void DeleteCookie(string name)
        {
            if (GetCookie(name) != null)
            {
                Response.Cookies.Remove(name);
                Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
