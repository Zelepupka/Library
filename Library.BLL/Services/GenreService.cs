using System.Linq;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class GenreService : BaseService<GenreDTO,Genre,GenreFilterDto>
    {
        public GenreService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        protected override IQueryable<Genre> GetFiltered(IQueryable<Genre> query,GenreFilterDto filter)
        {
            if (filter.Name != null)
            {
                query = query.Where(g => g.Name.Contains(filter.Name));
            }
            return query;
        }
    }
}