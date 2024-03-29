using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DataLayer.Context;
using EShop.IocConfig;
using EShop.Services.Contracts;
using EShop.Services.EFServices;
using EShop.ViewModels.Application;
using Microsoft.EntityFrameworkCore;


namespace EShop.Web
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
            // services.Configure<ConnectionStringsModel>(Configuration.GetSection("ApplicationDbContextConnection"));

            services.AddDbContext<EShopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContextConnection"));
            });
            //services.AddScoped<IUnitOfWork, EShopDbContext>();
            services.Configure<EmailConfigsModel>(options=> Configuration.GetSection("EmailConfigs"));
           services.AddCustomServices();
           services.AddControllersWithViews();
           //services.AddScoped<IProductServices, ProductServices>();

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
            });
        }
    }
}
