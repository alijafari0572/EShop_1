using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.Services.Contracts
{
    public interface IProductServices
    {
        void Add(Product product);
        List<Product> GetList();
    }
}
