using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Library.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : CrudController<GenreViewModel,GenreDTO,Genre,GenreFilterDto,Guid,DataTableGenreAjaxPostViewModel>
    {
        public GenresController(GenreService genreService,IMapper mapper)
            : base(genreService, mapper) { }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
    }
}
