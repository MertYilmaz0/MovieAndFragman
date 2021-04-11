using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
  public class GenreFragmanConfiguration : IEntityTypeConfiguration<GenreFragman>
    {
        public void Configure(EntityTypeBuilder<GenreFragman> builder)
        {
            builder.ToTable("GenreFragman");
            builder.HasKey(a => new { a.GenreID, a.FragmanID });
            builder.HasOne(a => a.Genre).WithMany(a => a.GenreFragmens).HasForeignKey(a => a.GenreID);
            builder.HasOne(a => a.Fragman).WithMany(a => a.GenreFragmens).HasForeignKey(a=>a.FragmanID);
        }
    }
}
