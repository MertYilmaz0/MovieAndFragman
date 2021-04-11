using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.EntityTypeConfiguration
{
   public class FragmanConfiguration : IEntityTypeConfiguration<Fragman>
    {
        public void Configure(EntityTypeBuilder<Fragman> builder)
        {
            builder.ToTable("Fragman");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
        }
    }
}
