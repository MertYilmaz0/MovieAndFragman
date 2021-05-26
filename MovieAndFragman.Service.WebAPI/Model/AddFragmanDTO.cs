using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class AddFragmanDTO
    {
        public int FragID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string FirstUrl { get; set; }
        public string SmallPoster { get; set; }
        public string MediumPoster { get; set; }
        public List<string> Documents { get; set; }
        public int CounterLike { get; set; }
        public int CounterDisLike { get; set; }
        public int CounterView { get; set; }
        public float Ratio { get; set; }// Beğenilme oranı
        public int GenreId { get; set; }
        public int RatingId { get; set; }
        public ICollection<UrlDto> UrlDto { get; set; }
        public ICollection<GenreDto> GenreDtos { get; set; }
    }
}
