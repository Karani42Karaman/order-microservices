using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Core.Repositories
{
    public interface IRepositoriy<TEntity> where TEntity : class
    {
        void CreateAsync(TEntity model);
        bool UpdateAsync(TEntity model);
        bool Remove(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetAsync(Guid id);
    }
}
