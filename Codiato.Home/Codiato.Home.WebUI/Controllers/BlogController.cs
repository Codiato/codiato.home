using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codiato.Home.WebUI.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LatestBlogPost = Codiato.Home.WebUI.Models.Repositories.PostRepository.Current.

            return View();
        }
    }
}
