using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Services
{
    public class BookService : BaseService<BookDTO,Book,BookFilterDto,Guid>, IBookService
    {
        public BookService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
        protected override IQueryable<Book> GetFiltered(IQueryable<Book> query, BookFilterDto filter)
        {
            if (filter.Search != null)
            {
                if (!String.IsNullOrEmpty(filter.Search.Value))
                {
                    query = query.Where(g => g.Name.ToLower().Contains(filter.Search.Value.ToLower()));
                }
            }

            if (!String.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(b=>b.Name.Contains(filter.Name));
            }
            if (filter.StartDate != null && filter.EndDate!=null)
            {
                query = query.Where(b => b.PublicationDate >= filter.StartDate).Where(b=>b.PublicationDate<=filter.EndDate);
            }

            if (filter.PublisherId != Guid.Empty)
            {
                query = query.Where(b=>b.Publisher.Id == filter.PublisherId);
            }
            return query;
        }

        protected override IQueryable<Book> GetInclude(IQueryable<Book> query)
        {
            query = query.Include(b => b.Publisher).Include(b=>b.Comments);
            return query;
        }

        public async Task<BookDTO> GetAsyncWithInclude(Guid id)
        {
            var allBooks = await _uow.GetRepository<Book>().GetAllAsync();
            var needBook = _mapper.Map<BookDTO>(await allBooks.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Id == id));
            return needBook;
        }
       
    }
}