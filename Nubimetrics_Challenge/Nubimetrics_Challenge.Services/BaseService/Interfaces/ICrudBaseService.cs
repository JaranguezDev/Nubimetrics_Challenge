using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.BaseService.Interfaces
{
    public interface ICrudBaseService<TDto>
        where TDto : class
    {
        Task<TDto> Create(TDto dto);
        Task Delete(Guid id);
        Task<TDto> Update(Guid id, TDto dto);
        Task<TDto> GetAsync(Guid id);
        Task<IEnumerable<TDto>> GetAsync();
    }
}
