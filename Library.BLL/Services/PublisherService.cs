using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class PublisherService : BaseService<PublisherDTO,Publisher,PublisherFilterDto>
    {
        public PublisherService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}