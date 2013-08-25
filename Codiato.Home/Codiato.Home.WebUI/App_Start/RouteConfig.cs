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
                defaults: new { controller = "Panel", action = "CreatePost" }
            );

            routes.MapRoute(
                name: "Deleter",
                url: "a/delete/{id}",
                defaults: new { controller = "Panel", action = "DeletePost" }
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