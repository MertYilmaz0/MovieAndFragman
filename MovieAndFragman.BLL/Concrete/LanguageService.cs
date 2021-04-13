using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class LanguageService : ILanguageBLL
    {

        ILanguageDAL languageDAL;
        public LanguageService(ILanguageDAL dAL)
        {
            languageDAL = dAL;
        }

        void Check(Language entity)
        {
            if (string.IsNullOrEmpty(entity.LanguageName))
            {
                throw new Exception("Dil adı boş bırakılamaz");
            }
        }

        public void Insert(Language entity)
        {
            Check(entity);
            languageDAL.Insert(entity);
        }

        public void Update(Language entity)
        {
            Check(entity);
            languageDAL.Update(entity);
        }
        public void Delete(Language entity)
        {
            entity.IsActive = false;
            languageDAL.Update(entity);
        }

        public void DeleteById(int entityId)
        {
            Language deleteLanguage = Get(entityId);
            deleteLanguage.IsActive = false;
            languageDAL.Update(deleteLanguage);
        }

        public Language Get(int entityId)
        {
            return languageDAL.Get(a => a.ID == entityId);
        }

        public ICollection<Language> GetAll()
        {
            return languageDAL.GetAll();
        }

      
    }
}
