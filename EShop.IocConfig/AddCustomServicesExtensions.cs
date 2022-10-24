using System;
using EShop.DataLayer.Context;
using EShop.Services.Contracts;
using EShop.Services.EFServices;
using EShop.ViewModels.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


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
            return services;

        }
    }
}
