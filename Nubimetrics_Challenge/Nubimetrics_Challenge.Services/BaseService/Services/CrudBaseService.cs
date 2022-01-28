using AutoMapper;
using Nubimetrics_Challenge.EntityFrameworkCore.Infraestructure.BaseRepository;
using Nubimetrics_Challenge.Services.BaseService.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.BaseService.Services
{
    public abstract class CrudBaseService<TEntity, TDto> : ICrudBaseService<TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CrudBaseService(
            IBaseRepository<TEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TDto>(result);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<TDto> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<IEnumerable<TDto>> GetAsync()
        {
            var entities = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> Update(Guid id, TDto dto)
        {
            var entity = await _repository.GetAsync(id);
            _mapper.Map(dto, entity);
            var result = await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TDto>(result);
        }
    }
}
