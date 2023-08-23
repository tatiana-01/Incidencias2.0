using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Persona;

namespace ApiIncidencias.Dtos.Rol;
    public class RolGetAllDTO
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Permisos {get;set;}
        public ICollection<PersonaDTO> Personas {get;set;} 
    }
