using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Testing
{
    public interface IContrato
    {
        public int Id { get; set; }

        bool SoyUnMetodo(int soyUnParametro);
    }
}
