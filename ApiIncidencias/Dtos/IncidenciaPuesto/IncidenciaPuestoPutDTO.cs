using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.IncidenciaPuesto;
    public class IncidenciaPuestoPutDTO
    {
        public int IdEstadoIncidencia { get; set; }
        public string Descripcion { get; set; }
    }
