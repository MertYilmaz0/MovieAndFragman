using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Models
{
    public class FragmanVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CounterLike { get; set; }
        public int CounterDisLike { get; set; }
        public float Ratio { get; set; }
        public int CounterView { get; set; }
    }
}
