using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
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
        where TViewModel : new()
    {
        protected BaseService<TDto, TEntity, TFilter, TKey> _service;
        protected IMapper _mapper;

        protected CrudController(BaseService<TDto,TEntity,TFilter,TKey> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Add()
        {
            return PartialView("Partials/Edit",new TViewModel());
        }


        [HttpPost]
        public virtual async Task Delete(TKey Id)
        {
            await _service.DeleteAsync(Id);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(TKey id)
        {
            var dto = await _service.GetAsync(x=>x.Id.Equals(id));

            var viewModel = _mapper.Map<TViewModel>(dto);

            return PartialView("Partials/Edit", viewModel);
        }

        [HttpPost]
        public virtual async Task Edit(TViewModel model)
        {
            var dto = _mapper.Map<TDto>(model);

            await _service.UpdateAsync(dto);
        }

        [HttpPost]
        public async Task<IActionResult> LoadData(DataTableBookAjaxPostViewModel tableInfo)
        {
            var filter = _mapper.Map<TFilter>(tableInfo);

            var genreData = await _service.SearchFor(filter);

            int recordsTotal = genreData.Count;

            var data = genreData.Items;

            return Json(new { draw = tableInfo.Draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data.ToList() });
        }

    }
}
