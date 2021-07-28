using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.Domain.AbstractClasses;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Services
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResult<TResult> : ServiceResult
    {
        public TResult Result { get; set; }
    }

    public abstract class BaseService<TDto, TEntity, TFilter, TKey> : IBaseService<TDto, TEntity, TFilter,TKey>
        where TDto : class, IBaseDto<TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TFilter : BaseFilterDto
        where TKey : IEquatable<TKey>
    {
        protected IUnitOfWork _uow;
        protected IMapper _mapper;

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

        protected virtual IQueryable<TEntity> GetInclude(IQueryable<TEntity> query)
        {
            return query;
        }
        public virtual async Task<QueryDTO<TDto>> SearchFor(TFilter filters)
        {
            var result = new QueryDTO<TDto>();

            var query = await _uow.GetRepository<TEntity>().GetAllAsync();

            if (filters == null)
            {
                result.Count = query.Count();

                query = GetInclude(query);

                result.Items = _mapper.Map<ICollection<TDto>>(query.ToList());

                return result;
            }

            query = GetFiltered(query,filters);
            query = GetInclude(query);

            result.Count = query.Count();

            // TODO: order by

            if (filters.Skip >= 0)
                query = query.Skip(filters.Start);

            if (filters.Length >= 0)
                query = query.Take(filters.Length);

            result.Items = _mapper.Map<ICollection<TDto>>(query.ToList());

            return result;
        }

        public async Task<TDto> GetAsync(Func<TEntity, bool> predicate)
        {
            var needItem = await _uow.GetRepository<TEntity>().GetAsync(predicate);

            return _mapper.Map<TDto>(needItem);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await _uow.GetRepository<TEntity>().GetAsync(x => x.Id.Equals(id));

            if (entity != null)
            {
                await _uow.GetRepository<TEntity>().DeleteAsync(entity);

                await _uow.SaveChangesAsync();
            }
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = await _uow.GetRepository<TEntity>().GetAsync(x => x.Id.Equals(dto.Id));

            _mapper.Map(dto, entity);

            entity = await _uow.GetRepository<TEntity>().UpdateAsync(entity);

            await _uow.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }
    }
}