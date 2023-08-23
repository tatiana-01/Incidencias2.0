using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Direccion;

namespace ApiIncidencias.Dtos.Ciudad;
    public class CiudadGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public int IdDepartamento { get; set; }
        public ICollection<DireccionDTO> Direcciones {get;set;}
    }
