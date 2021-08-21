using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class LoginVIewModel
    {
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Usuario { get; set; }
        [Display(Name="Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
