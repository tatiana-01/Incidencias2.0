using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class EPS:EntidadGenericaA
    {
        public ICollection<Persona> Personas {get;set;}
    }
