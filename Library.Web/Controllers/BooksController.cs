using System;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : CrudController<BookViewModel,BookDTO,Book,BookFilterDto,Guid>
    {
        public BooksController(BookService service, IMapper mapper) : base(service, mapper) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}