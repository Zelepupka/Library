using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels.EntityViewModels;


namespace Library.Web.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>();
            CreateMap<User, CommentUserViewModel>();
            CreateMap<UserDTO,User>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<CommentUserViewModel,UserDTO>();
            CreateMap<UserDTO, CommentUserViewModel>();
        }
    }
}