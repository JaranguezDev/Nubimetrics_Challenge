using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.EntityFrameworkCore.Infraestructure.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly NubimetricsContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(
            NubimetricsContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = _dbSet.Update(entity);
            return await Task.FromResult(result.Entity);
        }
    }
}
