using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Models
{
    public class GenreVM
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
