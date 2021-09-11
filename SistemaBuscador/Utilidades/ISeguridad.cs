using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Utilidades
{
    public interface ISeguridad
    {
        string Encriptar(string password);
    }
}
