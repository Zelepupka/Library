using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Services
{
    public abstract class BaseService<TDto, TEntity, TFilter> : IBaseService<TDto, TEntity, TFilter>
        where TDto : class
        where TEntity : class
        where TFilter : BaseFilterDto
    {

        private IUnitOfWork _uow;
        private IMapper _mapper;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<TEntity>(dto);

            entity = await _uow.GetRepository<TEntity>().AddAsync(entity);

            await _uow.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        protected virtual IQueryable<TEntity> GetFiltered(IQueryable<TEntity> query,TFilter filter)
        {
            return query;
        }

        public async Task<IEnumerable<TDto>> SearchFor(TFilter filters)
        {   
            var query = await _uow.GetRepository<TEntity>().GetAllAsync();
            if (filters == null)
            {
                return _mapper.Map<IEnumerable<TDto>>(query.ToList());
            }
            query = GetFiltered(query,filters);

            // TODO: order by

            if (filters.Skip >= 0)
                query = query.Skip(filters.Skip);

            if (filters.Take >= 0)
                query = query.Take(filters.Take);

            return _mapper.Map<IEnumerable<TDto>>(query.ToList());
        }

        public async Task<TDto> GetAsync(Func<TEntity, bool> predicate)
        {
            var needItem = await _uow.GetRepository<TEntity>().GetAsync(predicate);
            return _mapper.Map<TDto>(needItem);
        }

        public async Task DeleteAsync(Func<TEntity, bool> predicate)
        {
            await _uow.GetRepository<TEntity>().DeleteAsync(predicate);
            await _uow.SaveChangesAsync();
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<TEntity>(dto);

            entity = await _uow.GetRepository<TEntity>().UpdateAsync(entity);

            await _uow.SaveChangesAsync();


            return _mapper.Map<TDto>(entity);
        }
    }
}