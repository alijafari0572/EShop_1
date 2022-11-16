using System;
using EShop.Common.MVC;
using EShop.DataLayer.Context;
using EShop.Services;
using EShop.Services.Contracts;
using EShop.Services.EFServices;
using EShop.ViewModels.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EShop.Entities.Identity;
using EShop.Services.Contracts.Identity;
using EShop.Services.Identity;

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
            #region Register Identity Services
            services.AddScoped<IRoleManagerService, RoleManagerService>();
            services.AddScoped<RoleManager<Role>, RoleManagerService>();

            services.AddScoped<IRoleStoreService, RoleStoreService>();
            services.AddScoped<RoleStore<Role, EShopDbContext, int, UserRole, RoleClaim>, RoleStoreService>();

            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<UserManager<User>, UserManagerService>();

            services.AddScoped<IUserStoreServoce, UserStoreService>();
            services.AddScoped<UserStore<User, Role, EShopDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>,
                UserStoreService>();
            services.AddScoped<ISignInManagerService, SignInManagerService>();
            services.AddScoped<SignInManager<User>, SignInManagerService>();

            #endregion
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

                    Option.Lockout.AllowedForNewUsers = false;
                    Option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

                    Option.User.RequireUniqueEmail = true; 

                    Option.SignIn.RequireConfirmedEmail= true;
                    Option.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddUserStore<UserStoreService>()
                .AddUserManager<UserManagerService>()
                .AddRoleStore<RoleStoreService>()
                .AddRoleManager<RoleManagerService>()
                .AddSignInManager<SignInManagerService>()
                //.AddEntityFrameworkStores<EShopDbContext>()
                .AddDefaultTokenProviders();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddRazorViewRenderer();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            return services;

        }
        public static IServiceCollection AddRazorViewRenderer(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IViewRendererService, ViewRendererService>();
            return services;
        }
    }
}
