using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    public class Contrato : IContrato
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }

        public bool SoyUnMetodo(int soyUnParametro)
        {
            return false;
        }
    }
}
