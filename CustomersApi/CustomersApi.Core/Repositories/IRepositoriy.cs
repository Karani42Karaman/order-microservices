using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomersApi.Core.Repositories
{
    public interface IRepositoriy<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity model);
        Task UpdateAsync(TEntity model);
        void Remove(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetAsync(Guid id);
    }
}
