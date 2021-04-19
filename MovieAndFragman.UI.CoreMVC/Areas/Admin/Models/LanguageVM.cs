using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Models
{
    public class LanguageVM
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
