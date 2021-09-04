using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    public class ContratoDos : IContrato
    {
        public int Id { get ; set ; }

        public bool SoyUnMetodo(int soyUnParametro)
        {
            return true;
        }
    }
}
