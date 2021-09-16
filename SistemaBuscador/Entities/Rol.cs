using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
