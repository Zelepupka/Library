using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
 
    public class BooksController : CrudController<BookViewModel,BookDTO,Book,BookFilterDto,Guid,DataTableBookAjaxPostViewModel>
    {
        private readonly PublisherService _publisherService;
        private readonly BookService _bookService;
        private readonly UserManager<User> _userManager;
        
        public BooksController(CommentService commentService, UserManager<User> userManager, PublisherService publisherService, BookService bookService, IMapper mapper) : base(bookService, mapper)
        {
            _publisherService = publisherService;
            _bookService = bookService;
            _userManager = userManager;
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
            ViewBag.Publishers = await _publisherService.SearchFor(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadBooks(BookFilterDto filter)
        {
            var booksDto = await _bookService.SearchFor(filter);
            var booksViewModel = _mapper.Map<IEnumerable<BookViewModel>>(booksDto.Items);
            return Json(booksViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> BookPage(Guid id)
        {
            var book = _mapper.Map<BookViewModel>(await _bookService.GetBookAsync(id));
            return View(book);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _bookService.SearchFor(null);
            return Json(data.Items.ToList());
        }
    }

    }
