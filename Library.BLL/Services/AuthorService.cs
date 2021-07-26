using System;
using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class AuthorService : BaseService<AuthorDTO,Author,AuthorFilterDto,Guid>,IAuthorService
    {
        public AuthorService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        protected override IQueryable<Author> GetFiltered(IQueryable<Author> query, AuthorFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Search.Value))
            {
                query = query.Where(g => g.FirstName.ToLower().Contains(filter.Search.Value.ToLower()));
            }

            return query;
        }
    }
}