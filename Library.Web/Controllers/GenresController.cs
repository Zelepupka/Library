using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.Models;
using Library.Web.ViewModels;

namespace Library.Web.Controllers
{
    public class GenresController : CrudController<GenreViewModel,GenreDTO,Genre,GenreFilterDto,Guid>
    {
        public GenresController(GenreService genreService,IMapper mapper)
            : base(genreService, mapper) { }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
    }
}
