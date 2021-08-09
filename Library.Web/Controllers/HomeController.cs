using System;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Web.Interfaces;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using RabbitMQ.Client;


namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRabbitManager _rabbitManager;
            
        public HomeController(IRabbitManager rabbitManager,ILogger<HomeController> logger)
        {
            _rabbitManager = rabbitManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var num = new System.Random().Next(9000);  
            _rabbitManager.Publish(new
            {
                field1 = $"Hello-{num}",
                field2 = $"rabbit-{num}"
            }, "MyExchange", "topic", "#routingkey");

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
