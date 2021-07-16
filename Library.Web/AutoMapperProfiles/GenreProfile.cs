using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.DTO;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<GenreDTO,GenreViewModel>();
            CreateMap<GenreViewModel,GenreDTO>();
        }
    }
}
