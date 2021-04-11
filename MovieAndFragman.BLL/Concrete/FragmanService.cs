using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class FragmanService : IFragmanBLL
    {
        IFragmanDAL fragmanDAL;
        public FragmanService(IFragmanDAL dAL)
        {
            fragmanDAL = dAL;
        }
        //Todo : check fragman
        public void Insert(Fragman entity)
        {
            fragmanDAL.Insert(entity);
        }

        public void Update(Fragman entity)
        {
            fragmanDAL.Update(entity);
        }

        public void Delete(Fragman entity)
        {
            entity.IsActive = false;
            fragmanDAL.Update(entity);
        }

        public void DeleteById(int entityId)
        {
            Fragman delete = Get(entityId);
            delete.IsActive = false;
            fragmanDAL.Update(delete);
        }

        public Fragman Get(int entityId)
        {
            return fragmanDAL.Get(a => a.ID == entityId);
        }

        public ICollection<Fragman> GetAll()
        {
            return fragmanDAL.GetAll();
        }
    }
}
