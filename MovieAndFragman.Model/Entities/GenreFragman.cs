using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
   public class GenreFragman:IEntity
    {
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        public int FragmanID { get; set; }
        public Fragman Fragman { get; set; }
      
    }
}
