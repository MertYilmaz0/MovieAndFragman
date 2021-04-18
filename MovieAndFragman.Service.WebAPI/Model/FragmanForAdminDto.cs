using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class FragmanForAdminDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CounterLike { get; set; }
        public int CounterDisLike { get; set; }
        public float Ratio { get; set; }
    }
}
