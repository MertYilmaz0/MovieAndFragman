using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class Genre : BaseModel, IEntity
    {
        public string Name { get; set; }
        public ICollection<GenreFragman> GenreFragmens { get; set; }

    }
}
