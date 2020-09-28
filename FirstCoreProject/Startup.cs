using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using FirstCoreProject.Repository;
using FirstCoreProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreProject
{
    public class Startup
    {
        private IConfiguration _configuaration;
        public Startup(IConfiguration configuration )
        {
            _configuaration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(optional => optional.UseSqlServer(_configuaration.GetConnectionString("Library")));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();

            //app.Run(async n =>
            //{
            //    await n.Response.WriteAsync("This is the First Example of middleware");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This can execute all the files\n");
            //    await next();
            //});
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{Controller=Books}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
