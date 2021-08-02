using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating,RatingDTO>();
            CreateMap<RatingDTO, Rating>();
            CreateMap<RatingDTO, RatingViewModel>();
            CreateMap<RatingViewModel, RatingDTO>();
        }
    }
}