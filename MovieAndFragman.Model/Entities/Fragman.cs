using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Fragman : BaseModel, IEntity
    {
        public Fragman()
        {
            IsActive = false;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public int CounterLike { get; set; }
        public int CounterDisLike { get; set; }
        public int CounterView { get; set; }
        public float Ratio { get; set; }// Beğenilme oranı
        public int UserID { get; set; }
        public User User { get; set; }//yükleyici        
        public ICollection<GenreFragman> GenreFragmens { get; set; }
        public ICollection<FragComment> FragComments { get; set; }
        public ICollection<Rating> Ratings { get; set; }//izlenme
        public ICollection<Url> Urls { get; set; }//yol
    }
}
