using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class RolRepositorioTest : TestBase
    {
        [TestMethod]
        public async Task InsertarRol()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var repo = new RolRepositorio(context);
            var modelo = new RolCreacionModel() {Nombre="Rol Test"};

            //Ejecucion
            await repo.InsertarRol(modelo);
            var context2 = BuildContext(nombreBd);
            var list = await context2.Roles.ToListAsync();
            var resultado = list.Count();
            //Verificacion
            Assert.AreEqual(1, resultado);

        }

        [TestMethod]
        public async Task ObtenerRolPorId()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);

            //Ejecucion
            var rolDeLaBd = await repo.ObtenerRolPorId(1);
            //Verificacion
            Assert.IsNotNull(rolDeLaBd);
        }

        [TestMethod]
        public async Task ActualizarRol()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);
            var model = new RolEdicionModel() { Id = 1, Nombre = "Rol 1 Modificado" };


            //Ejecucion
            await repo.ActualizarRol(model);
            var context3 = BuildContext(nombreBd);
            var rolModificado = await context3.Roles.FirstOrDefaultAsync(x => x.Id == 1);
            var resultado = rolModificado.Nombre;
            //Verificacion
            Assert.AreEqual("Rol 1 Modificado", resultado);
        }


        [TestMethod]
        public async Task EliminarRol()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);

            //Ejecucion
            await repo.EliminarRol(1);
            var context3 = BuildContext(nombreBd);
            var listaRoles = await context3.Roles.ToListAsync();
            var resultado = listaRoles.Count;
            //Verificacion
            Assert.AreEqual(0, resultado);
        }

    }
}
