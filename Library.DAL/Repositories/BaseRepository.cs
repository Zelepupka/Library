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
    class BaseRepository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _db;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }
        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var needEntity = await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
