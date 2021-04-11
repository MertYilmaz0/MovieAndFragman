using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAndFragman.BLL.Concrete.DependencyInjection;

namespace MovieAndFragman.Service.WebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();//sadece controller dönecek
            services.AddScopeBLL();
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();


            }));
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");//clientla iletiþim için kaynak paylaþýmý yapýyoruz
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//Controller çalýþtýrmak için tanýmlandý
            });
        }
    }
}
