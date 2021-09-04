using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    public class Calculos : ICalculos
    {
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (DateTime.Today < fechaNacimiento.AddYears(edad))
                --edad;

            return edad;
        }
    }
}
