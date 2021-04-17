using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Abstract
{
    public interface IFragmanBLL:IBaseBLL<Fragman>
    {
        ICollection<Fragman> GetLastThirdFragman();
        ICollection<Fragman> GetByName(string name);
    }
}
