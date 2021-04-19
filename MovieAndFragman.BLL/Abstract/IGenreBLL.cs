using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Abstract
{
    public interface IGenreBLL:IBaseBLL<Genre>
    {
        List<Genre> GetByFragId(int id);
        ICollection<Genre> GetAllForUser();
    }
}
