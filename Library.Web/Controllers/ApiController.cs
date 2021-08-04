using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Library.Web.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ApiScope")]
    public class ApiController : ControllerBase
    {
        private readonly BookService _bookService;

        public ApiController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _bookService.SearchFor(null);
            return new JsonResult(data.Items.ToList());
        }

    }
}
