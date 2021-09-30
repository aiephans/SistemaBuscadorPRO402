using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class UsuarioCreacionModel
    {
        [Display(Name ="Nombre de usuario")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? RolId { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(8,ErrorMessage ="El campo {0} debe tener como mínimo {1} caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$",ErrorMessage ="La contraseña debe tener al menos una Mayuscula, minusculas, digitos y al menos 8 caracteres")]
        public string Password { get; set; }
        [Display(Name = "Repetir contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(8, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener al menos una Mayuscula, minusculas, digitos y al menos 8 caracteres")]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string RePassword { get; set; }
        public SelectList Roles { get; set; }
    }
}
