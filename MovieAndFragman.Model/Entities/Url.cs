using MovieAndFragman.Core.Entity;
using MovieAndFragman.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Url : BaseModel, IEntity
    {
        public Language Language { get; set; }//dil
        public string UrlPath { get; set; }//url uzantısı

        public int FragmanID { get; set; }
        public Fragman Fragman { get; set; }//bir urlin bir fragmanı olur
    }
}
