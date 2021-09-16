using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class RolCreacionModel
    {
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}
