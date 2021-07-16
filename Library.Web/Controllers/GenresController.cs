using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
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
            var data = await _genreService.SearchFor(null);
            return Json(new{data = data.ToList()});
        }
    }
}
