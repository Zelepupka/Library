using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO,Book>();
            CreateMap<BookDTO,BookViewModel>();
            CreateMap<BookViewModel, BookDTO>();
        }
    }
}