using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Usuario:EntidadGenericaInt     
    {
        public string UsuarioPersona { get; set; }
        public string Contraseña { get; set; }
        public Persona Persona  { get; set; }
        public string IdPersona { get; set; }
    }
