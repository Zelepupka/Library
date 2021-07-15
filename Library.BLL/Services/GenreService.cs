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

    }
}