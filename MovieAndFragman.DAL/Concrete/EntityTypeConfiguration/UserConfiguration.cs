using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.DAL.Helper;
using MovieAndFragman.Model.Entities;
using MovieAndFragman.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.UserName).HasMaxLength(20).IsRequired();
            builder.Property(a => a.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(25).IsRequired();
            builder.Property(a => a.PasswordHash).IsRequired();
            builder.Property(a => a.PasswordSalt).IsRequired();
            builder.Ignore(a => a.Password);

            PasswordHelperDAL.CreatePasswordHash("123", out byte[] _hash, out byte[] _salt);//"123" ü hash ve saltına ayırdık.

            builder.HasData(new User
            {
                ID = 1,
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                UserRole = UserRole.Admin,
                PasswordHash=_hash,
                PasswordSalt=_salt
            }
            //,
            //new User
            //{
            //    UserID = 2,
            //    UserName = "standard",
            //    FirstName = "standard",
            //    LastName = "standard",
            //    UserRole = UserRole.User
            //}
            );

        }
    }
}
