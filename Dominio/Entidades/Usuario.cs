using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Usuario:EntidadGenericaInt     
    {
        public string Email { get; set; }
        public string UsuarioPersona { get; set; }
        public string Contraseña { get; set; }
        public Persona Persona  { get; set; }
        public string IdPersona { get; set; }
        public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
        public ICollection<UsuarioRol> UsuarioRoles {get;set;}
    }
