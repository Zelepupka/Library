using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Interfaces;
using Library.BLL.Services;
using Library.Web.ViewModels;

namespace Library.Web.Controllers
{
    public class GenresController : Controller
    {
        private GenreService _genreService;
        private IMapper _mapper;

        public GenresController(GenreService genreService,IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> LoadData()
        {
            var draw = Request.Form["draw"].FirstOrDefault();

            var start = Request.Form["start"].FirstOrDefault();

            var length = Request.Form["length"].FirstOrDefault();

            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            var filter = new GenreFilterDto {Name = searchValue,Skip = skip, Take = pageSize};

            var genreData =await _genreService.SearchFor(null);

            int recordsTotal = genreData.Count();

            var data = await _genreService.SearchFor(filter);

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data.ToList()});
        }
    }
}
