using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codiato.Home.WebUI.Controllers
{
    public class PanelController : Controller
    {
        public ActionResult CreatePost()
        {
            return View("Poster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(string title, string body, string tags, string link)
        {
            Post p = new Post();
            p.Title = title;
            p.Content = body;
            p.PublishDate = DateTime.UtcNow;
            p.StaticLink = link;
            p.Tags = new List<Tag>();

            foreach (var tag in tags.Split(','))
            {
                Tag t = TagRepository.Current.Find(tag);
                if (t == null)
                    t = new Tag { TagName = tag };

                p.Tags.Add(t);
            }

            PostRepository.Current.Add(p);
            PostRepository.Current.Save();

            return View("Poster");
        }
    }
}
