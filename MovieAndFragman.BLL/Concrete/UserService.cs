using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.BLL.Helper;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        void Check(User user)
        {
            string fullname = user.FirstName + user.LastName;
            foreach (char item in fullname)
            {
                if (item != ' ')
                {
                    if (!char.IsLetter(item))
                    {
                        throw new Exception("Ad ve soyad sadece harflerden oluşmalıdır.");
                    }
                }
            }
            foreach (char item in user.Email)
            {
                if (item == ' ')
                {
                    throw new Exception("Email adresinde boşluk ' ' bırakmayınız.");
                }
            }
            if (!user.Email.Contains('@') || !user.Email.Contains(".com"))
            {
                throw new Exception("Lütfen e-mailinizi doğru formatta yazınız.(....@....com)");
            }
            if (user.PhoneNumber != null)
            {
                if (user.PhoneNumber.Length != 11)
                {
                    throw new Exception("Telefon numarası 11 haneli olmalıdır.");
                }
                foreach (char item in user.PhoneNumber)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new Exception("Telefon numarası sadece sayılardan oluşmalıdır.");
                    }
                }
            }
            if (user.BrithDate.AddYears(18) > DateTime.Now)
            {
                throw new Exception("18 yaşından küçükler üye olamaz.");
            }
        }
        void CheckUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("*Bilgileri boş geçilemez.");
            }
        }
        void IsThereAny(User user)
        {
            foreach (string item in GetAllUsersName())
            {
                if (user.UserName == item)
                {
                    throw new Exception("Bu kullanıcı adı mevcut. Lütfen farklı bir kullanıcı adı giriniz.");
                }
            }
            foreach (string item in GetAllMails())
            {
                if (user.Email == item)
                {
                    throw new Exception("Bu mail adresi mevcut. Lütfen farklı bir mail adresi giriniz.");
                }
            }
        }
        List<string> GetAllUsersName()
        {
            List<string> userNames = new List<string>();
            List<User> users = userDAL.GetAll().ToList();
            foreach (User item in users)
            {
                userNames.Add(item.UserName);
            }
            return userNames;
        }
        List<string> GetAllMails()
        {
            List<string> mails = new List<string>();
            List<User> users = userDAL.GetAll().ToList();
            foreach (User item in users)
            {
                mails.Add(item.Email);
            }
            return mails;
        }
        void CheckUserName(User user)
        {
            if (user.UserName.Length > 30)
            {
                throw new Exception("Kullanıcı adı max 30 karakterden oluşmalıdır.");
            }
        }
        void CheckUserUpdate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.UserName) || user.PasswordHash == null || user.PasswordSalt == null)
            {
                throw new Exception("*Bilgileri boş geçilemez.");
            }
        }

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
            CheckUser(entity);
            Check(entity);
            CheckUserName(entity);
            IsThereAny(entity);
            entity = HashSaltCreate(entity);
            userDAL.Insert(entity);
        }

        public void Update(User entity)
        {
            Check(entity);
            CheckUserUpdate(entity);
            CheckUserName(entity);
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

        public User GetLoginUser(string email,string password)
        {
            User user = userDAL.Get(a => a.Email == email);
            if (user==null)
            {
                throw new Exception("Kullanıcı bilgilerinizi kontrol ediniz.");
            }
            if (!HashSaltVerify(user))
            {
                throw new Exception("Kullanıcı bilgilerinizi kontrol ediniz.");
            }
            return user;
        }        
    }
}
