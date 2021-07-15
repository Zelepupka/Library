using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<T> GetRepository<T>() where T : class;
        public Task SaveChangesAsync();
    }
}