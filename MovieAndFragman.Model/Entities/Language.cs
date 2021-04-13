using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
   public class Language:BaseModel,IEntity
    {
        public Language()
        {
            IsActive = true;
        }

        public string LanguageName { get; set; }
        public string Description { get; set; }

      

    }
}
