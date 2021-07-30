using System;
using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Services
{
    public class CommentService : BaseService<CommentDTO,Comment,CommentFilterDto,Guid>
    {
        public CommentService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
        protected override IQueryable<Comment> GetInclude(IQueryable<Comment> query)
        {
            query = query.Include(c => c.User);
            return query;
        }

        protected override IQueryable<Comment> GetFiltered(IQueryable<Comment> query, CommentFilterDto filter)
        {
            if (filter.BookId != Guid.Empty)
            {
                query = query.Where(c=>c.BookId == filter.BookId);
            }
            return query;
        }
    }
}