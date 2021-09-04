using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    public class ServicioMilitar
    {
        private readonly ICalculos _calculos;

        // fecha nacimiento -Sexo string m o f
        // apta > 18 y M

        public ServicioMilitar(ICalculos calculos)
        {
            _calculos = calculos;
        }

        public bool EsApto(DateTime fechaNacimiento, string sexo)
        {
            bool resultado = false;
            //
            if (sexo == "M")
            {
               
                int edad = _calculos.CalcularEdad(fechaNacimiento);
                if (edad >= 18)
                {
                    resultado = true;
                }
            }

            return resultado;
        }
    }
}
