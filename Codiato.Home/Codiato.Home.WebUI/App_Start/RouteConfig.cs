using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Codiato.Home.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Control Panel Urls
            
            routes.MapRoute(
                name: "Poster",
                url: "a/post",
                defaults: new { controller = "BlogPanel", action = "CreatePost" }
            );

            routes.MapRoute(
                name: "Deleter",
                url: "a/delete/{id}",
                defaults: new { controller = "BlogPanel", action = "DeletePost" }
            );

            #endregion

            #region Blog

            routes.MapRoute(
                name: "BlogHome",
                url: "blog/",
                defaults: new { controller = "Blog", action = "Index" }
            );

            routes.MapRoute(
                name: "BlogSingle",
                url: "blog/p/{urlKey}",
                defaults: new { controller = "Blog", action = "Archive" }
            );

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}