using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.BLL.Helper;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete
{
    class UserService : IUserBLL
    {
        IUserDAL userDAL;
        public UserService(IUserDAL dAL)
        {
            userDAL = dAL;
        }

        //TODO : Check ler eklenecek User

        User HashSaltCreate(User user)
        {
            PasswordHelperBLL.CreatePasswordHash(user.Password, out byte[] _hash, out byte[] _salt);
            user.PasswordHash = _hash;
            user.PasswordSalt = _salt;
            return user;
        }

        bool HashSaltVerify(User user)//  Verify=Doğrulama >>>>Login işlemlerinde lazım olacak
        {
            return PasswordHelperBLL.VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt);
        }

        public void Insert(User entity)
        {
            entity = HashSaltCreate(entity);
            userDAL.Insert(entity);
        }

        public void Update(User entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Password))
            {
                entity = HashSaltCreate(entity);
            }
            userDAL.Update(entity);
        }

        public void Delete(User entity)
        {
            entity.IsActive = false;
            Update(entity);
        }

        public void DeleteById(int entityId)
        {
            User delete = Get(entityId);
            delete.IsActive = false;
            Update(delete);
        }

        public User Get(int entityId)
        {
            return userDAL.Get(a => a.ID == entityId);
        }

        public ICollection<User> GetAll()
        {
            return userDAL.GetAll(a => a.UserRole != Model.Enums.UserRole.Admin);
        }
    }
}
