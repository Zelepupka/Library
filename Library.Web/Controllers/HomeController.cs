using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _manager;
        public HomeController( UserManager<User> manager, ILogger<HomeController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Secure()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
