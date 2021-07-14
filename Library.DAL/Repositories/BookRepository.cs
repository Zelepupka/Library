using System;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL.Context;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IQueryable<Book>> GetAllAsync()
        {
            return _db.Books.AsNoTracking();
        }


        public async Task<Book> GetAsync(Guid id)
        {
            return await _db.Books.FirstOrDefaultAsync(b=>b.Id == id);
        }

        public async Task<Book> AddAsync(Book item)
        {
            await _db.Books.AddAsync(item);
            return item;
        }

        public async Task<Book> UpdateAsync(Book item)
        {
            _db.Books.Update(item);
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var needBook = await GetAsync(id);
            if (needBook != null)
            { 
                _db.Books.Remove(needBook);
            }
        }
    }
}