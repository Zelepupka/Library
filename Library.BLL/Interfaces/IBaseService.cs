using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Interfaces;

namespace Library.BLL.Interfaces
{
    public interface IBaseService<TDto, TEntity, TFilter> 
        where TDto : class
        where TEntity : class
    {
        Task<TDto> AddAsync(TDto item);
        Task<IEnumerable<TDto>> SearchFor(TFilter filters);
        Task<TDto> GetAsync(Func<TEntity,bool> predicate);
        Task DeleteAsync(Func<TEntity, bool> predicate);
        Task<TDto> UpdateAsync(TDto item);
    }
}