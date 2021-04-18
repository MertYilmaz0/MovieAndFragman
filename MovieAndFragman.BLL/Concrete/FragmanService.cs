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
            if (string.IsNullOrWhiteSpace(fragman.Name) || string.IsNullOrWhiteSpace(fragman.Description))
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
            return fragmanDAL.Get(a => a.ID == entityId, a => a.Ratings);
        }

        public ICollection<Fragman> GetAll()
        {
            return fragmanDAL.GetAll(null, a => a.GenreFragmens);
        }
        public ICollection<Fragman> GetLastThirdFragman()
        {
            return fragmanDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(3).ToList();
        }
        public ICollection<Fragman> GetByName(string name)
        {
            return fragmanDAL.GetAll(a => a.Name.Contains(name));
        }
        public void UpdateRating(int fid, int uid, char token)
        {
            Fragman fragman = Get(fid);
            int plus = 0;
            int minus = 0;
            Rating rating = fragman.Ratings.SingleOrDefault(a => a.UserID == uid);
            if (rating != null)
            {
                if (rating.UserID == uid)
                {
                    if (token == 'u')
                    {
                        if (!rating.LoveLike)
                        {
                            plus = 1;
                        }
                        if (rating.UnLike)
                        {
                            minus = -1;
                        }
                        rating.LoveLike = true;
                        rating.UnLike = false;
                    }
                    else if (token == 'd')
                    {
                        if (!rating.UnLike)
                        {
                            minus = 1;
                        }
                        if (rating.LoveLike)
                        {
                            plus = -1;
                        }
                        rating.LoveLike = false;
                        rating.UnLike = true;
                    }
                }

                fragman.CounterLike += plus;
                fragman.CounterDisLike += minus;
                Update(fragman);
            }
        }

        public void AddRating(int fid, int uid)
        {
            Fragman fragman = Get(fid);
            Rating rating = fragman.Ratings.SingleOrDefault(a => a.UserID == uid);
            if (rating == null)
            {
                fragman.CounterView += 1;
                fragman.Ratings.Add(new Rating { FragmanID = fid, UserID = uid });
                Update(fragman);
            }
        }
    }
}
