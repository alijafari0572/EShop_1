using EShop.DataLayer.Context;
using EShop.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.EFServices
{
    public class GenericServices<TEntity> : IGenericServices<TEntity>where TEntity : class
    {
        private readonly DataLayer.Context.IUnitOfWork _uow;
        private readonly DbSet<TEntity> _entity;
        public GenericServices(IUnitOfWork uow)
        {
            _uow = uow;
            _entity=uow.Set<TEntity>();
        }

        public void Add(TEntity entity)
       =>_entity.Add(entity);
        public void Remove(TEntity entity)
        =>_entity.Remove(entity);
        public void Update(TEntity entity)
        =>_entity.Update(entity);
        public TEntity FindById(int id)
      => _entity.Find(id);
        public Task<List<TEntity>> GetAll()
      => _entity.ToListAsync();

        public async Task AddAsync(TEntity entity)
        {
           await _entity.AddAsync(entity);
        }

        public TEntity FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
