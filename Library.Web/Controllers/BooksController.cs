using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
 
    public class BooksController : CrudController<BookViewModel,BookDTO,Book,BookFilterDto,Guid,DataTableBookAjaxPostViewModel>
    {
        private PublisherService _publisherService { get; set; }
        private BookService _bookService { get; set; }



        public BooksController(PublisherService publisherService, BookService bookService, IMapper mapper) : base(bookService, mapper)
        {
            _publisherService = publisherService;
            _bookService = bookService;
        }
        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Publishers = await _publisherService.SearchFor(null);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Add()
        {
            ViewBag.Publishers = await _publisherService.SearchFor(null);
            return PartialView("Partials/Edit",new BookViewModel());
        }

        public async Task<IActionResult> UserIndex()
        {
            return View();
        }

        public async Task<IActionResult> LoadBooks()
        {
            var booksDto = await _bookService.SearchFor(null);
            var booksViewModel = _mapper.Map<IEnumerable<BookViewModel>>(booksDto.Items);
            return Json(booksViewModel);
        }

    }
}