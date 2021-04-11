using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class UrlService : IUrlBLL
    {
        IUrlDAL urlDAL;
        public UrlService(IUrlDAL dAL)
        {
            urlDAL = dAL;
        }
        //Todo : Check url
        public void Insert(Url entity)
        {
            urlDAL.Insert(entity);
        }

        public void Update(Url entity)
        {
            urlDAL.Update(entity);
        }

        public void Delete(Url entity)
        {
            entity.IsActive = false;
            Update(entity);
        }

        public void DeleteById(int entityId)
        {
            Url delete = Get(entityId);
            delete.IsActive = false;
            Update(delete);
        }

        public Url Get(int entityId)
        {
            return urlDAL.Get(a => a.ID == entityId);
        }

        public ICollection<Url> GetAll()
        {
            return urlDAL.GetAll();
        }
    }
}
