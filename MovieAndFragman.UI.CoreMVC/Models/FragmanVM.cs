using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Models
{
    public class FragmanVM
    {
        public int FragID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string FirstUrl { get; set; }
        public string SmallPoster { get; set; }
        public string MediumPoster { get; set; }
        public string Document { get; set; }
    }
}
