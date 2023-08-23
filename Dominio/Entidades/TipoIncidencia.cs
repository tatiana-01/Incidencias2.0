using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class TipoIncidencia:EntidadGenericaA
    {
        public ICollection<Incidencia> Incidencias {get;set;}
    }
