using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult Index()
        {
            DateTime fecha = new DateTime(2000, 12, 1);
            string sexo = "M";
            var servicioMilitar = new ServicioMilitar(new Calculos());
            var resultado = servicioMilitar.EsApto(fecha, sexo);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVIewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _loginRepository.UserExist(model.Usuario, model.Password))
                {
                    _loginRepository.SetSessionAndCookie(HttpContext);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El usuario o contraseña no es valido");
                }
            }
            return View("Index", model);
        }
    }
}
