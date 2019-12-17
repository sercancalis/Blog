using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Info",
              url: "Info",
              defaults: new { controller = "Admin", action = "Info" }
            );

            routes.MapRoute(
                name: "Security",
                url: "Security",
                defaults: new { controller = "Security", action = "Index" }
            );

            routes.MapRoute(
                name: "InActiveComments",
                url: "InActiveComments",
                defaults: new { controller = "Admin", action = "InActiveComments" }
            );

            routes.MapRoute(
                name: "Comments",
                url: "Comments",
                defaults: new { controller = "Admin", action = "Comments" }
            );

            routes.MapRoute(
                name: "Tags",
                url: "Tags",
                defaults: new { controller = "Admin", action = "Tags" }
            );

            routes.MapRoute(
                name: "UpdateProject",
                url: "UpdateProject-{ID}",
                defaults: new { controller = "Admin", action = "UpdateProject", ID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddProject",
                url: "AddProject",
                defaults: new { controller = "Admin", action = "AddProject" }
            );

            routes.MapRoute(
                name: "Projects",
                url: "Projects",
                defaults: new { controller = "Admin", action = "Projects" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
