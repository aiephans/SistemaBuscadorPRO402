using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVIewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }
            return View("Privacy");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Prueba() 
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
