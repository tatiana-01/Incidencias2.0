using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.IncidenciaPuesto;

namespace ApiIncidencias.Dtos.EstadoIncidencia;
    public class EstadoIncidenciaGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<IncidenciaPuestoDTO> IncidenciaPuestos {get;set;}
    }
