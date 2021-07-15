﻿using System;
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
            return await _dbSet.FindAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            _dbSet.Add(item);
            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _db.Update(item);
            return item;
        }

        public async Task DeleteAsync(Func<TEntity, bool> predicate)
        {
            var needEntity = await GetAsync(predicate);
            _dbSet.Remove(needEntity);
        }

    }
}
