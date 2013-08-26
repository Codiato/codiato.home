using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codiato.Home.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IPostRepository _postRepository;

        public BlogController()
        {
            _postRepository = PostRepository.Current;
        }

        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ActionResult Index()
        {
            ViewBag.LatestBlogPost = _postRepository.LatestPost();
            ViewBag.RecentPosts = _postRepository.RecentPosts(10);

            return View();
        }

        public ActionResult Archive(string urlKey)
        {
            Post p = _postRepository.Find(urlKey);
            if (p == null)
                return HttpNotFound();

            return View(p);
        }
			
    }
}
