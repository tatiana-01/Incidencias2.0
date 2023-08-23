using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class EstadoIncidencia:EntidadGenericaA
    {
        public ICollection<IncidenciaPuesto> IncidenciaPuestos {get;set;}
    }
