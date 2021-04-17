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
        void UpdateRating(int fid, int uid, char token);
        void AddRating(int fid, int uid);
    }
}
