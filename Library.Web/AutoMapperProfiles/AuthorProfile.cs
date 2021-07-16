using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author,AuthorDTO>();
            CreateMap<AuthorDTO,Author>();
            CreateMap<AuthorDTO,AuthorViewModel>();
            CreateMap<AuthorViewModel,AuthorDTO>();
        }
    }
}