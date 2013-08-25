﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models
{
    public class Tag
    {
        [Key]        
        public string TagName { get; set; }

        public List<Post> Posts { get; set; }
    }
}