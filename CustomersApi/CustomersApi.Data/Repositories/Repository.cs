using CustomersApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Data.Repositories
{
    public class Repository<TEntity> : IRepositoriy<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task CreateAsync(TEntity model)
        {
            try
            {

                await Context.Set<TEntity>().AddAsync(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetAsync(Guid id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(Guid id)
        {
            var model = GetAsync(id).Result;
            Context.Set<TEntity>().Remove(model);
        }

        public Task UpdateAsync(TEntity model)
        {
            Context.Update(model);
            return Task.CompletedTask;
        }
    }
}
