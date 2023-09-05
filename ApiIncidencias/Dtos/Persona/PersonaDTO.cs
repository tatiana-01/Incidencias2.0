using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Persona;
    public class PersonaDTO
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        public DateOnly FechaNacimiento {get;set;}
        public int IdGenero {get;set;}
        public int ? IdEPS {get;set;}
        public int ? IdARL {get;set;}
    }
