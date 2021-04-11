using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Fragman : BaseModel, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }//afiş
        public int UserID { get; set; }
        public User User { get; set; }//yükleyici
        public string InitialRelease { get; set; }// ilk gösterim
        public string Director { get; set; } //Yönetmen
        public string Production { get; set; } // Yapımcı
        public float IMDB { get; set; }
        public ICollection<GenreFragman> GenreFragmens { get; set; }

        public ICollection<FragComment> FragComments { get; set; }
        public ICollection<Rating> Ratings { get; set; }//izlenme
        public ICollection<Url> Urls { get; set; }//yol
    }
}
