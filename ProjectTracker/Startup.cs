using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectTracker.Models;

namespace ProjectTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //                .SetBasePath(env.ContentRootPath)
            //                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //                .AddEnvironmentVariables();
            //Configuration = builder.Build();
            Configuration = configuration;
            CurrentEnvironment = env;

        }

        public IWebHostEnvironment CurrentEnvironment { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services
                .AddControllersWithViews();
            services.AddDbContext<ProjectTrackerContext>(options =>
            options.UseSqlServer((Configuration.GetConnectionString("ProjectTracker"))));
            services.BuildServiceProvider().GetService<ProjectTrackerContext>().Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
