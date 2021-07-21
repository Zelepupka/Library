using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Context;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> 
        where TEntity : class

    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return _dbSet.AsQueryable().AsNoTracking();
        }

        public async Task<TEntity> GetAsync(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);

            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _db.Update(item);

            return item;
        }

        public async Task DeleteAsync(TEntity item)
        {
            _dbSet.Remove(item);
        }

    }
}
