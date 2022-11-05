using System;
using EShop.DataLayer.Context;
using EShop.Entities;
using EShop.Services.Contracts;
using EShop.Services.EFServices;
using EShop.ViewModels.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace EShop.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            //var provider = services.BuildServiceProvider();
            //var connectionStrings = provider.GetRequiredService<IOptionsMonitor<ConnectionStringsModel>>().CurrentValue;
            //services.AddDbContext<EShopDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionStrings.EShopDbContextConnection);
            //});
            services.AddScoped<IUnitOfWork, EShopDbContext>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddIdentity<User, Role>(Option =>
                {
                    //configure identity options
                    Option.Password.RequireDigit = false;
                    Option.Password.RequireLowercase = false;
                    Option.Password.RequireUppercase = false;
                    Option.Password.RequireNonAlphanumeric = false;
                    Option.Password.RequiredUniqueChars = 0;
                    Option.Password.RequiredLength = 4;
                    Option.User.RequireUniqueEmail = true;
                    Option.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddUserManager<UserManager<User>>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<EShopDbContext>()
                .AddDefaultTokenProviders();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            return services;

        }
    }
}
