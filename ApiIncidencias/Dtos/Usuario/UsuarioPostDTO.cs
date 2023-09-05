using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Usuario;
    public class UsuarioPostDTO
    {
        public string Email { get; set; }
        public string UsuarioPersona { get; set; }
        public string Contraseña { get; set; }
        public string IdPersona { get; set; }
    }
