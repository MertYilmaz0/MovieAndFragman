using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
   public class UrlConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.ToTable("Url");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
        }
    }
}
