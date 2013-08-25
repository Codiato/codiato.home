using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Codiato.Home.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (Codiato.Home.WebUI.Models.HomeContext ctx = new Models.HomeContext())
            {
                Codiato.Home.WebUI.Models.Tag t = new Models.Tag();
                t.TagName = "firt-tag";

                ctx.Tags.Add(t);
                ctx.SaveChanges();
            }

            return Content("Salam");
        }			
    }
}
