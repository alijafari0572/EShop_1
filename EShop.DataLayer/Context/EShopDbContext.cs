using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities;
using EShop.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataLayer.Context
{
    public class EShopDbContext :
       IdentityDbContext<User, Role, int,UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
    IUnitOfWork
    {
        public EShopDbContext(DbContextOptions options)
         : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        //public Task<int> SaveChangesAsync()
        //{
        //    return base.SaveChangesAsync();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EShopDbContext).Assembly);
        }
    }
}
