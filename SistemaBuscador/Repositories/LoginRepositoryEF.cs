using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class LoginRepositoryEF : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISeguridad _seguridad;

        public LoginRepositoryEF(ApplicationDbContext context, ISeguridad seguridad)
        {
            _context = context;
            _seguridad = seguridad;
        }
        public void SetSessionAndCookie(HttpContext context)
        {
            Guid sessionId = Guid.NewGuid();
            context.Session.SetString("sessionId", sessionId.ToString());
            context.Response.Cookies.Append("sessionId", sessionId.ToString());
        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            var resultado = false;

            //Logica que ocupa EF

            var usuarioBD = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.NombreUsuario == usuario && x.Password == _seguridad.Encriptar(password));

            if (usuarioBD!=null) {
                resultado = true;
            }

            return resultado;
        }
    }
}
