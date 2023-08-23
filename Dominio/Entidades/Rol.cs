using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Rol:EntidadGenericaA
    {
        public string Permisos {get;set;}
        public ICollection<Persona> Personas {get;set;}
    }
