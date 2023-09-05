using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Usuario;
    public class UsuarioGetAllDTO
    {
        public int Id {get; set;}
        public string Email { get; set; }
        public string UsuarioPersona { get; set; }
    }
