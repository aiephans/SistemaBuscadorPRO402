using Microsoft.EntityFrameworkCore;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly ApplicationDbContext _context;

        public RolRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<RolListaModelo>> ObtenerListaRoles()
        {
            var respuesta = new List<RolListaModelo>();
            var listaDelaBd = await _context.Roles.ToListAsync();

            foreach (var rolDb in listaDelaBd)
            {
                //Mapeo de entidades
                var newRolLista = new RolListaModelo()
                {
                    Id = rolDb.Id,
                    Nombre = rolDb.Nombre
                };

                respuesta.Add(newRolLista);
            }

            return respuesta;
        }

        public async Task InsertarRol(RolCreacionModel model)
        {
            var nuevoRol = new Rol()
            {
                Nombre = model.Nombre,
            };
            _context.Roles.Add(nuevoRol);
            await _context.SaveChangesAsync();
        }

        public async Task<RolEdicionModel> ObtenerRolPorId(int id)
        {
            var respuesta = new RolEdicionModel() { };
            var roldb = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id); //Linq
            if (roldb != null)
            {
                respuesta.Id = roldb.Id;
                respuesta.Nombre = roldb.Nombre;
            }

            return respuesta;
        }

        public async Task ActualizarRol(RolEdicionModel model)
        {
            var rolDb = await _context.Roles.FirstOrDefaultAsync(x => x.Id == model.Id);
            rolDb.Nombre = model.Nombre;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarRol(int id)
        {
            var rol = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
        }

    }
}
