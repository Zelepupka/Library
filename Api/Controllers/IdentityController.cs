using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.BLL;
using Library.BLL.Services;


namespace Api.Controllers
{
    [ApiController]
    [Route("Identity")]
    [Authorize(Policy = "ApiScope")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return new JsonResult("Hmm");
        }
    }
}