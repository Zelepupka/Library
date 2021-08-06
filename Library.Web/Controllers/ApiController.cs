using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.BLL.DTO;
using Library.BLL.Services;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Library.Web.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class ApiController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly RatingService _ratingService;

        public ApiController(RatingService ratingService,BookService bookService)
        {
            _ratingService = ratingService;
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ApiScope")]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _bookService.SearchFor(null);
            return new JsonResult(data.Items.ToList());
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy ="UserScope")]
        public async Task<IActionResult> SetRating(int value,Guid bookId)
        {

            var userId =  this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var ratingDto = new RatingDTO
            {
                BookId = bookId,
                Value = value,
                UserId = userId.Value,
            };
            await _ratingService.AddAsync(ratingDto);
            return Ok();
        }

    }
}
