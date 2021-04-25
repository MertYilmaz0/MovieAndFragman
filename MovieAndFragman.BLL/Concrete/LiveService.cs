using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class LiveService : ILiveBLL
    {

        ILiveDAL liveDAL;
        public LiveService(ILiveDAL dAL)
        {
            liveDAL = dAL;
        }

        public void Insert(Live entity)
        {
            liveDAL.Insert(entity);
        }

        public void Update(Live entity)
        {
            liveDAL.Update(entity);
        }
  
        public void Delete(Live entity)
        {
            entity.IsActive = false;
            liveDAL.Update(entity);
        }

        public void DeleteById(int entityId)
        {
            Live delete = Get(entityId);
            delete.IsActive = false;
            liveDAL.Update(delete);
        }

        public Live Get(int entityId)
        {
            return liveDAL.Get(a => a.ID == entityId);
        }

        public ICollection<Live> GetAll()
        {
            return liveDAL.GetAll();
        }

    }
}
