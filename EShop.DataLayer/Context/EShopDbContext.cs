using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataLayer.Context
{
    public class EShopDbContext:DbContext
    {
        public EShopDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
