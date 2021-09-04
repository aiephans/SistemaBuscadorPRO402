using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.Test.PruebasUnitarias.TestTest
{
    [TestClass]
    public class ServicioMilitarTest
    {
        [TestMethod]
        public void NoEsValidoPorSexo()
        {
            //Preparacion
            string sexo = "F";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockOk());

            //Ejecucion

            bool resultado = clase.EsApto(fechaNac,sexo);

            //verificacion

            Assert.IsFalse(resultado);

        }
        [TestMethod]
        public void NoEsValidoEdad()
        {
            //Preparacion
            string sexo = "M";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculoMockNok());

            //Ejecucion

            bool resultado = clase.EsApto(fechaNac, sexo);

            //verificacion

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void NoEsValidoEdadYSexo()
        {
            //Preparacion
            string sexo = "F";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculoMockNok());

            //Ejecucion

            bool resultado = clase.EsApto(fechaNac, sexo);

            //verificacion

            Assert.IsFalse(resultado);
        }


        [TestMethod]
        public void EsValido()
        {
            //Preparacion
            string sexo = "M";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockOk());

            //Ejecucion

            bool resultado = clase.EsApto(fechaNac, sexo);

            //verificacion

            Assert.IsTrue(resultado);
        }
    }
}
