using MovieAndFragman.Core.DataAccess.EntityFramework;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.Repository
{
    class LiveRepository : EFRepositoryBase<Live, MovieAndFragmanDbContext>, ILiveDAL
    {
    }
}
