using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.DTO;
using Library.Domain.Interfaces;

namespace Library.BLL.Interfaces
{
    public interface IBaseService<TDto, TEntity, TFilter, TKey> 
        where TDto : class
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        Task<TDto> AddAsync(TDto item);

        Task<QueryDTO<TDto>> SearchFor(TFilter filters);

        Task<TDto> GetAsync(Func<TEntity,bool> predicate);

        Task DeleteAsync(TKey id);

        Task<TDto> UpdateAsync(TDto item);

    }
}