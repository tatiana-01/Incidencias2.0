using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Puesto;

namespace ApiIncidencias.Dtos.Salon;
    public class SalonGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public int NroPuestos {get;set;}
        public int IdArea { get; set; }
        public ICollection<PuestoDTO> Puestos {get;set;}

    }
