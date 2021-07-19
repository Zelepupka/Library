using System;
using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class GenreService : BaseService<GenreDTO,Genre,GenreFilterDto,Guid>
    {
        public GenreService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        protected override IQueryable<Genre> GetFiltered(IQueryable<Genre> query,GenreFilterDto filter)
        {
          
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(g => g.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            return query;
        }
    }
}