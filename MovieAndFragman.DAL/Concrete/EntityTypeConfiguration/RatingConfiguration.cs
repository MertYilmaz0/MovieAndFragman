using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
   public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.HasKey(a => new { a.UserID, a.FragmanID });

            builder.HasOne(a => a.User).WithMany(a => a.Ratings).HasForeignKey(a => a.UserID).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(a => a.Fragman).WithMany(a => a.Ratings).HasForeignKey(a => a.FragmanID).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}
