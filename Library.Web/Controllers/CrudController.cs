using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.AbstractClasses;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public abstract class CrudController<TViewModel, TDto, TEntity, TFilter, TKey> : Controller 
        where TDto : class
        where TEntity : BaseEntity<TKey>
        where TFilter : BaseFilterDto
        where TKey : IEquatable<TKey>
    {
        protected BaseService<TDto, TEntity, TFilter, TKey> _service;
        protected IMapper _mapper;

        protected CrudController(BaseService<TDto,TEntity,TFilter,TKey> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        protected virtual async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        protected virtual async Task<IActionResult> Add(TViewModel item)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<TDto>(item);
                await _service.AddAsync(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        protected virtual async Task Delete(TKey id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpGet]
        protected virtual async Task<IActionResult> Edit(TKey id)
        {
            var dto = await _service.GetAsync(x=>x.Id.Equals(id));

            var viewModel = _mapper.Map<TViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        protected virtual async Task<IActionResult> Edit(TViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<TDto>(model);
                await _service.UpdateAsync(dto);
            }
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public async Task<IActionResult> LoadData(JsTable tableInfo)
        //{
        //    var searchValue = Request.Form["search[value]"];

        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //    var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();

        //    int pageSize = tableInfo.Length != null ? Convert.ToInt32(tableInfo.Length) : 0;

        //    int skip = tableInfo.Start != null ? Convert.ToInt32(tableInfo.Start) : 0;

        //    var filter = _mapper.Map<TFilter>(tableInfo); //new TEntity { Name = searchValue, Skip = skip, Take = pageSize };

        //    var genreData = await _service.SearchFor(filter);

        //    int recordsTotal = genreData.Count;

        //    var data = genreData.Items;

        //    return Json(new { draw = tableInfo.Draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data.ToList() });
        //}
    }
}
