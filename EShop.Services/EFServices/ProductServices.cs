using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DataLayer.Context;
using EShop.Entities;
using EShop.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.EFServices
{
    public class ProductServices:IProductServices
    {
        private readonly EShopDbContext _context;
        //private readonly DbSet<Product> _products;

        public ProductServices(EShopDbContext context)
        {
            _context = context;
            //_products = _context.Set<Product>();
        }

        public void Add(Product product)
        {
           _context.Products.Add(product);
        }

        public List<Product> GetList()
        {
            return _context.Products.ToList();
        }
    }
}
