using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(Func<T, bool> predicate);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(Func<T, bool> predicate);
    }
}