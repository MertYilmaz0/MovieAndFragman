using Microsoft.Extensions.DependencyInjection;
using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.DAL.Concrete.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.BLL.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IFragmanBLL, FragmanService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IUrlBLL, UrlService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<ILanguageBLL, LanguageService>();
        }

    }
}
