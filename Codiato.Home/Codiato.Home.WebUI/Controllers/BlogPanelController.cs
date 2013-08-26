﻿using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codiato.Home.WebUI.Controllers
{
    public class BlogPanelController : Controller
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

        [HttpPost]        
        public ActionResult DeletePost(long id)
        {
            Post p = PostRepository.Current.Find(id);
            if (p == null)
                return HttpNotFound();

            PostRepository.Current.Delete(p);
            PostRepository.Current.Save();

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