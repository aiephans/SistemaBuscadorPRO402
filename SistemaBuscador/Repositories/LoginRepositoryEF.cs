using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class LoginRepositoryEF : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
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
                .FirstOrDefaultAsync(x => x.NombreUsuario == usuario && x.Password == password);

            if (usuarioBD!=null) {
                resultado = true;
            }

            return resultado;
        }
    }
}
