using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos;

    public class IncidenciaPuestoDTO
    {
        public int IdIncidencia { get; set; }
        public int IdPuesto { get; set; }
        public int IdEstadoIncidencia { get; set; }
        public string Descripcion { get; set; }
    }
