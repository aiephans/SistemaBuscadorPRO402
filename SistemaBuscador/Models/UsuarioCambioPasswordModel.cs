﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class UsuarioCambioPasswordModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
