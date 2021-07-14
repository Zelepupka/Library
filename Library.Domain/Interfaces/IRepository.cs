using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> SearchAsync(int id);
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}