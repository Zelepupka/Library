using System;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : CrudController<BookViewModel,BookDTO,Book,BookFilterDto,Guid,DataTableBookAjaxPostViewModel>
    {
        public BooksController(PublisherService pubService, BookService service, IMapper mapper) : base(service, mapper)
        {
            _publisherService = pubService;
        }
        private PublisherService _publisherService { get; set; }
        public async Task<IActionResult> Index()
        {
            ViewBag.Publishers = await _publisherService.SearchFor(null);
            return View();
        }

        public override async Task<IActionResult> Add()
        {
            ViewBag.Publishers = await _publisherService.SearchFor(null);
            return PartialView("Partials/Edit",new BookViewModel());
        }
    }
}