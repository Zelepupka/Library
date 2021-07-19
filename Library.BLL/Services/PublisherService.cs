using System;
using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class PublisherService : BaseService<PublisherDTO,Publisher,PublisherFilterDto,Guid>
    {
        public PublisherService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
        protected override IQueryable<Publisher> GetFiltered(IQueryable<Publisher> query, PublisherFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            return query;
        }
    }
}