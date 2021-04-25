using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class LiveDto
    {
        public int LiveID { get; set; }
        public string Name { get; set; }
        public string BroadcastPath { get; set; }
        public string ImagePath { get; set; }
        public string ImageSPath { get; set; }
        public string ImageLPath { get; set; }
    }
}
