using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Salon;
    public class SalonDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public int NroPuestos {get;set;}
        public int IdArea { get; set; }
    }
