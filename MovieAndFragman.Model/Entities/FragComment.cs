using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class FragComment:IEntity
    {
       
        public string Comment { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int FragmanID { get; set; }
        public Fragman Fragman { get; set; }
   

      
    }
}
