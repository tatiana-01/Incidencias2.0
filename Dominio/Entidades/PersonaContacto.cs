using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class PersonaContacto
    {
        public Persona Persona {get;set;}
        public string IdPersona {get;set;}
        public Contacto Contacto {get;set;}
        public int IdContacto {get;set;}
    }
