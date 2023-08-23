using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Ciudad;
    public class CiudadDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public int IdDepartamento { get; set; }
    }
