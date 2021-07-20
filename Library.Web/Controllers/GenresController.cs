using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
        
        [HttpPost]
        public async Task<IActionResult> LoadData(JsTable tableInfo)
        {

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = tableInfo.Length != null ? Convert.ToInt32(tableInfo.Length) : 0;

            int skip = tableInfo.Start != null ? Convert.ToInt32(tableInfo.Start) : 0;

            var filter = new GenreFilterDto {Name = searchValue,Skip = skip, Take = pageSize};

            var genreData = await _service.SearchFor(filter);

            int recordsTotal = genreData.Count;

            var data = genreData.Items;

            return Json(new { draw = tableInfo.Draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data.ToList()});
        }

       
    }
}
