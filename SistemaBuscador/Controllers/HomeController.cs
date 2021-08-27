using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
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
            var repo = new LoginRepository();
            if (ModelState.IsValid)
            {
                if (repo.UserExist(model.Usuario, model.Password))
                {
                    Guid sessionId = Guid.NewGuid();
                    HttpContext.Session.SetString("sessionId", sessionId.ToString());
                    Response.Cookies.Append("sessionId", sessionId.ToString());
                    return View("Privacy");
                }
                else {
                    ModelState.AddModelError(string.Empty, "El usuario o contraseña no es valido");
                }
            }
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            string sessionId = Request.Cookies["sessionId"];
            if (string.IsNullOrEmpty(sessionId) || !sessionId.Equals(HttpContext.Session.GetString("sessionId")))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Prueba() 
        {
            string sessionId = Request.Cookies["sessionId"];
            if (string.IsNullOrEmpty(sessionId) || !sessionId.Equals(HttpContext.Session.GetString("sessionId")))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
