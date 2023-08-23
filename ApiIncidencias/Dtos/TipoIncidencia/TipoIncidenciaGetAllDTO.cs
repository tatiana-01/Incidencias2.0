using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Incidencia;

namespace ApiIncidencias.Dtos.TipoIncidencia;
    public class TipoIncidenciaGetAllDTO
    {
         public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<IncidenciaDTO> Incidencias {get;set;}
    }
