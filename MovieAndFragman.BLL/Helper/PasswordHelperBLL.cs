﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MovieAndFragman.BLL.Helper
{
    class PasswordHelperBLL
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//Girilen şifreyi hash ve salt'a ayırır.
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//Kullanıcıcnı hash ve salt'ını kullanarak şifrenin doğruluğu kontrol edilir.
        {
            var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
