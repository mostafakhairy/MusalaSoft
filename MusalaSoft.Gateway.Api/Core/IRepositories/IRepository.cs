using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T enttity);
        Task Update(T entity);
        Task Delete(object id);
        Task Delete(Expression<Func<T, bool>> where);
        Task<T> GetById(object id);
        Task<IQueryable<T>> GetManyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
