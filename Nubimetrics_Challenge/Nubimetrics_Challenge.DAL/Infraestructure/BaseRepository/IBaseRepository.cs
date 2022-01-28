using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.EntityFrameworkCore.Infraestructure.BaseRepository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task SaveChangesAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
