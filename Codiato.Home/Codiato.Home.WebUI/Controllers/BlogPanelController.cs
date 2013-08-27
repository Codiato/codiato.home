using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Codiato.Home.WebUI.Controllers
{
    [Authorize]
    public class BlogPanelController : Controller
    {
        private IPostRepository _PostRepository;
        private ITagRepository _TagRepository;

        public BlogPanelController()
        {
            _PostRepository = PostRepository.Current;
            _TagRepository = TagRepository.Current;
        }

        public BlogPanelController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _PostRepository = postRepository;
            _TagRepository = tagRepository;
        }

        public ActionResult CreatePost()
        {
            return View("Poster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(string title, string content, string tags, string link)
        {
            Post p = new Post();
            p.Title = title;
            p.Content = content;
            p.PublishDate = DateTime.UtcNow;
            p.StaticLink = link;
            p.Tags = new List<Tag>();
            p.Writer = Membership.GetUser().UserName;

            foreach (var tag in tags.Split(','))
            {                
                Tag t = _TagRepository.Find(tag.Trim());
                if (t == null)
                    t = new Tag { TagName = tag.Trim() };

                p.Tags.Add(t);
            }

            _PostRepository.Add(p);
            _PostRepository.Save();

            return View("Poster");
        }
        
        public ActionResult EditPost(long id)
        {
            Post p = _PostRepository.Find(id);
            if (p == null)
                return HttpNotFound();

            return View("Poster", p);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(long id, string title, string content, string tags, string link)
        {
            Post p = _PostRepository.Find(id);
            if (p == null)
                return HttpNotFound();
            p.Title = title;
            p.Content = content;
            p.PublishDate = DateTime.UtcNow;
            p.StaticLink = link;

            string[] newTagNames=tags.Split(',');
            IQueryable<Tag> removeTags = p.Tags.Where(x=>newTagNames.Count(y=>y == x.TagName)==0).AsQueryable();
            string[] addTags = newTagNames.Where(x=>p.Tags.Count(y=>y.TagName == x) == 0).ToArray();

            foreach (var tag in removeTags.ToList())
            {
                p.Tags.Remove(tag);
            }
            foreach (var tag in addTags)
            {
                Tag t = _TagRepository.Find(tag.Trim());
                if (t == null)
                    t = new Tag { TagName = tag.Trim() };

                p.Tags.Add(t);
            }

            _PostRepository.Save();

            return View("Poster", p);
        }
        
        [HttpPost]        
        public ActionResult DeletePost(long id)
        {
            Post p = _PostRepository.Find(id);
            if (p == null)
                return HttpNotFound();

            _PostRepository.Delete(p);
            _PostRepository.Save();

            return Content("Done O.O");
        }
			

        #region CKEditor
        public ActionResult Upload(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string fileName = upload.FileName;

            string basePath = Server.MapPath("~/Content/uploads");
            upload.SaveAs(basePath + "\\" + fileName);

            return Content("آپلود با موفقیت انجام شد.");
        }

        public ActionResult Browse(string CKEditorFuncNum)
        {
            List<FileInformation> fileInfoList = GetCurrentFiles();

            var model = new FileListingViewModel
            {
                Files = fileInfoList,
                CKEditorFuncNum = CKEditorFuncNum
            };

            return View(model);
        }

        private List<FileInformation> GetCurrentFiles()
        {
            string basePath = Server.MapPath("~/Content/uploads");
            List<FileInformation> fileInfoList = new List<FileInformation>();
            string[] files = Directory.GetFiles(basePath);
            files.ToList().ForEach(file =>
            {
                fileInfoList.Add(new FileInformation { FileName = Path.GetFileName(file) });
            });
            return fileInfoList;
        }
        #endregion
    }
}
