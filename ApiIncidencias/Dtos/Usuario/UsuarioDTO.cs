using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Rol;

namespace ApiIncidencias.Dtos.Usuario;
    public class UsuarioDTO
    {
        public int Id {get; set;}
        public string Email { get; set; }
        public string UsuarioPersona { get; set; }
        public string Contraseña { get; set; }
        public ICollection<RolDTO> Roles {get;set;}
    }
