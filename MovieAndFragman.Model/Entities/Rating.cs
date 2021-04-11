using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    //İzlenme Takip
   public class Rating:IEntity
    {
      
        public bool LoveLike { get; set; }//beğenme
        public bool UnLike { get; set; }//beğenmeme
        public int UserID { get; set; }
        public User User { get; set; }//kullanıcı
        public int FragmanID { get; set; }
        public Fragman Fragman { get; set; }
    }
}
