using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using WebApp.Domain.SharedKernel;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Domain.BlogAggregate;
using WebApp.Infrastructure;
using WebApp.Queries;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var envConnectionstring = "";
            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                envConnectionstring = Configuration.GetConnectionString("MyDbConnection");
            }
            else
            {
                envConnectionstring = Configuration.GetConnectionString("DefaultConnection");         
            }


            services.AddDbContext<BlogContext>(options =>
                    options.UseSqlServer(envConnectionstring) );

            services.AddTransient<IBlogQueries, BlogQueries>(s => new BlogQueries(envConnectionstring));


            // Drop database
            //services.BuildServiceProvider().GetService<BlogContext>().Database.EnsureDeleted();
            // Automatically perform database migratio
            services.BuildServiceProvider().GetService<BlogContext>().Database.Migrate();
            services.AddTransient<IUnitOfWork, BlogContext>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
