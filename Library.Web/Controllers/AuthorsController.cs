using Microsoft.AspNetCore.Mvc;
using System;
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
    public class AuthorsController : CrudController<AuthorViewModel,AuthorDTO,Author,AuthorFilterDto,Guid,DataTableAuthorAjaxPostViewModel>
    {
        public AuthorsController(AuthorService service, IMapper mapper) : base(service, mapper) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
