using System;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class RatingsService : BaseService<RatingDTO,Rating,RatingFilterDto,Guid>
    {
        public RatingsService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
    }
}