using System;
using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class BookService : BaseService<BookDTO,Book,BookFilterDto,Guid>
    {
        public BookService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
        protected override IQueryable<Book> GetFiltered(IQueryable<Book> query, BookFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Search.Value))
            {
                query = query.Where(g => g.Name.ToLower().Contains(filter.Search.Value.ToLower()));
            }
            return query;
        }

    }
}