using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieAndFragman.DAL.Concrete.EntityTypeConfiguration;
using MovieAndFragman.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL
{
    class MovieAndFragmanDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
            IConfiguration configuration = configBuilder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<FragComment> FragComments { get; set; }
        public DbSet<Fragman> Fragmans { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreFragman> GenreFragmens { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FragCommentConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreFragmanConfiguration());
            modelBuilder.ApplyConfiguration(new UrlConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new FragmanConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
