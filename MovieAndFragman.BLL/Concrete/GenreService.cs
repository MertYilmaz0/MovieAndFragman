using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class GenreService : IGenreBLL
    {
        IGenreDAL genreDAL;
        public GenreService(IGenreDAL dAL)
        {
            genreDAL = dAL;
        }
        //TODO: check genre
        public void Insert(Genre entity)
        {
            genreDAL.Insert(entity);
        }

        public void Update(Genre entity)
        {
            genreDAL.Update(entity);
        }

        public void Delete(Genre entity)
        {
            entity.IsActive = false;
            genreDAL.Update(entity);
        }

        public void DeleteById(int entityId)
        {
            Genre delete = Get(entityId);
            delete.IsActive = false;
            genreDAL.Update(delete);
        }

        public Genre Get(int entityId)
        {
            return genreDAL.Get(a=>a.ID== entityId);
        }

        public ICollection<Genre> GetAll()
        {
            return genreDAL.GetAll();
        }
    }
}
