using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Library.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly BookService _bookService;
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService, UserManager<User> userManager, IMapper mapper,
            BookService bookService)
        {
            _commentService = commentService;
            _bookService = bookService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task Add(CommentViewModel viewModel)
        {
            ClaimsPrincipal currentUser = User;
            var user = await _userManager.GetUserAsync(currentUser);
            viewModel.Date = DateTime.Now;
            var commentDto = _mapper.Map<CommentDTO>(viewModel);
            commentDto.User = user;
            await _commentService.AddAsync(commentDto);
        }

        public async Task<IActionResult> LoadComments(CommentFilterDto filter)
        {
            var comments = await _commentService.SearchFor(filter);
            var viewmodel = _mapper.Map<IEnumerable<CommentViewModel>>(comments.Items);
            return Json(viewmodel);
        }
    }
}
