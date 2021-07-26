using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!string.IsNullOrEmpty(filter.Search.Value))
            {
                query = query.Where(g => g.Name.ToLower().Contains(filter.Search.Value.ToLower()));
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
            query = query.Include(b => b.Publisher);
            return query;
        }
    }
}