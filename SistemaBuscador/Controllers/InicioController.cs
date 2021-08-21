using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

    }
}
