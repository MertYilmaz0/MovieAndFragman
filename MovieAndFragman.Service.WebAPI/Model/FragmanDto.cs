using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class FragmanDto
    {
        public FragmanDto()
        {
            Genres = new HashSet<GenreDto>();
        }
        public int FragID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
