using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Abstract
{
    public interface ILanguageBLL:IBaseBLL<Language>
    {
        ICollection<Language> GetAllActive();
    }
}
