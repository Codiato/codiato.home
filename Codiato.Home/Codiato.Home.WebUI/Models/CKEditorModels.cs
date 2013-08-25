using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models
{
    public class FileInformation
    {
        public string FileName { get; set; }
    }

    public class FileListingViewModel
    {
        public List<FileInformation> Files { get; set; }
        public string CKEditorFuncNum { get; set; }
    }
}