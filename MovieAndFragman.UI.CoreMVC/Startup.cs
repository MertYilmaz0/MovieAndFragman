using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAndFragman.UI.CoreMVC.Models.MyList;
using MovieAndFragman.UI.CoreMVC.Helper;

namespace MovieAndFragman.UI.CoreMVC
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;


            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a => a.LoginPath = new PathString("/Account/Login"));//loginPatth
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.Use((httpContext, nextMiddleware) =>
            {
                httpContext.Session.Set<MyList>("myList", new MyList());
                return nextMiddleware();
            });
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               

                endpoints.MapControllerRoute(
                    name: "AllMovie",
                    pattern: "allMovie",
                    defaults: new { controller = "Movie", action="Movies" }
                    );
                endpoints.MapControllerRoute(
                    name: "MovieSingle",
                    pattern: "movieSingle",
                    defaults: new { controller = "Movie", action = "MovieSinglePage" }
                    );

                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

                    );
            

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
