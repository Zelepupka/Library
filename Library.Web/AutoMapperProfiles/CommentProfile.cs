using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<CommentDTO, CommentViewModel>().ForMember(c=>c.User,c=>c.MapFrom(dto=>dto.User));
            CreateMap<CommentViewModel, CommentDTO>();

        }
    }
}