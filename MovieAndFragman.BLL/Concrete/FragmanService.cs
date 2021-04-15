using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        void Check(Fragman fragman)
        {
            if (string.IsNullOrWhiteSpace(fragman.Name)|| string.IsNullOrWhiteSpace(fragman.Description))
            {
                throw new Exception("* Yerleri boş bırakmayınız.");
            }
            if (string.IsNullOrWhiteSpace(fragman.Poster))
            {
                throw new Exception("Fragmanın posterini belirtiniz.");
            }            
        }

        public void Insert(Fragman entity)
        {
            Check(entity);
            fragmanDAL.Insert(entity);
        }

        public void Update(Fragman entity)
        {
            Check(entity);
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
        public ICollection<Fragman> GetLastThirdFragman()
        {
            return fragmanDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(3).ToList();
        }
    }
}
