using System.Collections.Generic;
using Library.DAL.Context;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> _repositories { get; set; }
        private readonly ApplicationDbContext _db;

        public EFUnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type,new Repository<T>(_db));
            }
            return (Repository<T>) _repositories[type];

        }

    }
}