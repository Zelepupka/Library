using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher,PublisherDTO>();
            CreateMap<PublisherDTO, Publisher>();
            CreateMap<PublisherViewModel, PublisherDTO>();
            CreateMap<PublisherDTO,PublisherViewModel>();

        }
    }
}