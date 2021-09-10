using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertatUsuario(UsuarioCreacionModel model)
        {
            var nuevoUsuario = new Usuario()
            {
             NombreUsuario = model.NombreUsuario,
             Nombres = model.Nombres,
             Apellidos = model.Apellidos,
             RolId = (int)model.RolId,
             Password = model.Password
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
        }
    }
}
