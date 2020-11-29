using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Context;
using Restaurant.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<TEntity> _table;
        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            _table.Add(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(object Id)
        {
            return await _table.FindAsync(Id);
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _table.Update(entity);
            return Task.CompletedTask;
        }
    }
}
