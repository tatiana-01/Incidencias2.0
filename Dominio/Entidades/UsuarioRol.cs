using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class UsuarioRol
    {
        public Usuario Usuario {get; set;}
        public int IdUsuario {get; set;}
        public Rol Rol {get; set;}
        public int IdRol {get; set;}
    }
