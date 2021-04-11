using Microsoft.EntityFrameworkCore;
using MovieAndFragman.DAL.Concrete.EntityTypeConfiguration;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL
{
    class MovieAndFragmanDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01; Database = MovieAndFragman; uid = bilal; pwd = 123");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<FragComment> FragComments { get; set; }
        public DbSet<Fragman> Fragmans { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreFragman> GenreFragmens { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FragCommentConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreFragmanConfiguration());
            modelBuilder.ApplyConfiguration(new UrlConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new FragmanConfiguration());
           

            base.OnModelCreating(modelBuilder);
        }


    }
}
