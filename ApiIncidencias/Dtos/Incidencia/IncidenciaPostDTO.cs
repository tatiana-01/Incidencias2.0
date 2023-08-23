using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Incidencia;
    public class IncidenciaPostDTO
    {
        public int IdTipoIncidencia {get;set;}
        public int IdCategoria { get; set; }
        public string IdPersona { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
    }
