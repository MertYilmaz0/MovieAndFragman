using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
   public class FragCommentConfiguration : IEntityTypeConfiguration<FragComment>
    {
        public void Configure(EntityTypeBuilder<FragComment> builder)
        {
            builder.ToTable("FragComment");
            builder.HasKey(a => new { a.UserID, a.FragmanID });
            builder.HasOne(a => a.User).WithMany(a => a.FragComments).HasForeignKey(a => a.UserID).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(a => a.Fragman).WithMany(a => a.FragComments).HasForeignKey(a => a.FragmanID).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}
