using Microsoft.EntityFrameworkCore;
using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using MusalaSoft.GatewayApp.Api.Infrastracture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(TEntity enttity)
        {
            await _dbContext.Set<TEntity>().AddAsync(enttity);
        }

        public async Task Delete(object id)
        {
            var entity =  await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(Expression<Func<TEntity, bool>> where)
        {
            TEntity entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(where);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        public async Task<TEntity> GetById(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(where);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;
        }
    }
}
