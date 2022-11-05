using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Contracts
{
    public interface IGenericServices<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity FindById(int id);
        TEntity FindByIdAsync(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllAsync();
    }
}
