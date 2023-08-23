using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Verificacion;

namespace ApiIncidencias.Dtos.EstadoVerificacion;
    public class EstadoVerificacionGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<VerificacionDTO> Verificaciones {get;set;}  
    }
