using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.Test.PruebasUnitarias.TestTest
{
    [TestClass]
    public class CalculosTest
    {
        [TestMethod]
        public void CumpleDespuesdeHoy() 
        {
            //preparacion
            DateTime fecha = new DateTime(2000, 12, 1);
            var clase = new Calculos();

            //ejecucion
            int edad = clase.CalcularEdad(fecha);

            //verificacion

            Assert.AreEqual(20, edad);
        
        }

        [TestMethod]
        public void CumpleAntesdeHoy()
        {
            //preparacion
            DateTime fecha = new DateTime(2000, 1, 1);
            var clase = new Calculos();

            //ejecucion
            int edad = clase.CalcularEdad(fecha);

            //verificacion

            Assert.AreEqual(21, edad);

        }
    }
}
