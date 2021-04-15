using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class UrlDto
    {
        public int UrlId { get; set; }
        public string UrlPath { get; set; }
        public int LanguageID { get; set; }
        public string Language { get; set; }
    }
}
