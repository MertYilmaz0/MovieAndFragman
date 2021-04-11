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
            services.AddControllers();//sadece controller d�necek
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
            app.UseCors("MyPolicy");//clientla ileti�im i�in kaynak payla��m� yap�yoruz
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//Controller �al��t�rmak i�in tan�mland�
            });
        }
    }
}
