using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Abstract
{
    public interface IUserBLL:IBaseBLL<User>
    {
        User GetLoginUser(string email, string password);
    }
}
