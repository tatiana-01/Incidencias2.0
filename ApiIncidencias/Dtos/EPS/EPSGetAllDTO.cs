using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Persona;

namespace ApiIncidencias.Dtos.EPS;
    public class EPSGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<PersonaDTO> Personas {get;set;}
    }
