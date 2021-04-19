using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class LanguageDto
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
