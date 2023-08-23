using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class ARL:EntidadGenericaA
    {
        public ICollection<Persona> Personas {get;set;}
    }
