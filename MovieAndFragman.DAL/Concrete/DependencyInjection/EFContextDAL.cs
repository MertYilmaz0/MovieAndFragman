using Microsoft.Extensions.DependencyInjection;
using MovieAndFragman.DAL.Abstract;
using MovieAndFragman.DAL.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.DAL.Concrete.DependencyInjection
{
    public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddScoped<IFragmanDAL, FragmanRepository>();
            services.AddScoped<IGenreDAL, GenreRepository>();
            services.AddScoped<IUrlDAL, UrlRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
            services.AddScoped<ILanguageDAL, LanguageRepository>();
        }

    }
}
