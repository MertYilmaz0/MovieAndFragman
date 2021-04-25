using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class PodcastService : IPodcastBLL
    {

        IPodcastDAL podcastDAL;

        public PodcastService(IPodcastDAL dAL)
        {
            podcastDAL = dAL;
        }


        public void Insert(Podcast entity)
        {
            podcastDAL.Insert(entity);
        }

        public void Update(Podcast entity)
        {
            podcastDAL.Update(entity);
        }
        public void Delete(Podcast entity)
        {
            entity.IsActive = false;
            podcastDAL.Update(entity);
        }
        public Podcast Get(int entityId)
        {
            return podcastDAL.Get(a => a.ID == entityId);
        }

        public void DeleteById(int entityId)
        {
            Podcast delete = Get(entityId);
            delete.IsActive = false;
            podcastDAL.Update(delete);
        }

        public ICollection<Podcast> GetAll()
        {
            return podcastDAL.GetAll();
        }

    }
}
