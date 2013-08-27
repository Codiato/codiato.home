﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models
{
    public class Post
    {
        [Key]        
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }                        
        public string StaticLink { get; set; }
        public string Writer { get; set; }
        
        public virtual List<Tag> Tags { get; set; }

        public Post()
        {}

        public Post(string title, string content, 
            string staticLink, string writer, DateTime publishDate)
        {
            Title = title;
            Content = content;
            PublishDate = publishDate;
            StaticLink = staticLink;
            Writer = writer;
        }
    }
}