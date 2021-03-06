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
    public class GenreService : BaseService<GenreDTO,Genre,GenreFilterDto,Guid>,IGenreService
    {
        public GenreService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        protected override IQueryable<Genre> GetFiltered(IQueryable<Genre> query,GenreFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Search.Value))
            {
                query = query.Where(g => g.Name.ToLower().Contains(filter.Search.Value.ToLower()));
            }

            return query;
        }
    }
}