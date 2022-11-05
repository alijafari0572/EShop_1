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
    public class ProductServices:GenericServices<Product>, IProductServices
    {
        private readonly DbSet<Product> _products;
        private readonly IUnitOfWork _uow;
        public ProductServices(IUnitOfWork uow)
            :base(uow)
        {
            _uow = uow;
            _products = _uow.Set<Product>();
        }

        public void Add(Product product)
        {
            //_context.Products.Add(product);
            _products.Add(product);
        }

        public List<Product> GetList()
        {
            return _products.ToList();
        }
    }
}
