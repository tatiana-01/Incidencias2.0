using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Persona;
using ApiIncidencias.Dtos.Usuario;

namespace ApiIncidencias.Dtos.Rol;
    public class RolGetAllDTO
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Permisos {get;set;}
        public ICollection<UsuarioDTO> Usuarios {get;set;} 
    }
