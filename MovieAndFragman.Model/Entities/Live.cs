using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Live:BaseModel,IEntity
    {
        public Live()
        {
            IsActive = true;
        }
        public string Name { get; set; }
        public string BroadcastPath { get; set; }
        public string ImagePath { get; set; }
        public string ImageSPath { get; set; }
        public string ImageLPath { get; set; }
    }
}
