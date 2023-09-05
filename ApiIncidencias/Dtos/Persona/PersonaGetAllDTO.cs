using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Incidencia;
using ApiIncidencias.Dtos.Verificacion;

namespace ApiIncidencias.Dtos.Persona;
    public class PersonaGetAllDTO
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        public DateOnly FechaNacimiento {get;set;}
        public int IdGenero {get;set;}
        public int IdEPS {get;set;}
        public int IdARL {get;set;}
        public ICollection<PersonaContactoDTO> PersonasContactos {get;set;}
        public ICollection<IncidenciaDTO> Incidencias {get;set;}
        public ICollection<PersonaDireccionDTO> PersonaDirecciones {get;set;}
        public ICollection<VerificacionDTO> Verificaciones {get;set;}
    }
