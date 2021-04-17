using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Models
{
    public class RatingVM
    {
        public int CounterLike { get; set; }
        public int CounterDislike { get; set; }
        public float Ratio { get; set; }
    }
}
