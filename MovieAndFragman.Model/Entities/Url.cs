using MovieAndFragman.Core.Entity;
using MovieAndFragman.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Url : BaseModel, IEntity
    {
        public Url()
        {
            IsActive = true;
        }
        public string UrlPath { get; set; }//url uzantısı
        public int LanguageID { get; set; }
        public Language Language { get; set; }//Dil
        public int FragmanID { get; set; }
        public Fragman Fragman { get; set; }//bir urlin bir fragmanı olur
    }
}
