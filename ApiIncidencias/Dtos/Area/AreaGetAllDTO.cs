using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Salon;

namespace ApiIncidencias.Dtos.Area;
    public class AreaGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public string Descripcion { get; set; }
        public ICollection<SalonDTO> Salones {get;set;}
    }
